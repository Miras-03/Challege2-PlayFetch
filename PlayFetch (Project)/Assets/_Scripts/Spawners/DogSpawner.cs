using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public sealed class DogSpawner : MonoBehaviour
{
    [SerializeField] Dog dogPrefab;
    private ObjectPool<Dog> dogPool;

    private Vector3 spawnPos = new Vector3(17, 0, 0);
    private Quaternion spawnRot = Quaternion.Euler(0, -90, 0);
    private const float waitSecond = 0.5f;
    private bool canInstantiate = true;

    private void Awake() =>
        dogPool = new ObjectPool<Dog>(CreateObject, EnableObject, DisableObject, DestroyObject,
            collectionCheck: false,
            maxSize: 10);

    public void SpawnWithDelay() => StartCoroutine(DelayAndInstantiate());

    private IEnumerator DelayAndInstantiate()
    {
        Dog prefab = dogPool.Get();
        prefab.transform.position = spawnPos;
        prefab.transform.rotation = spawnRot;
        prefab.Init(ReleaseObject);

        yield return new WaitForSeconds(waitSecond);
        CanInstantiate = true;
    }

    private Dog CreateObject() => Instantiate(dogPrefab);

    private void EnableObject(Dog dog) => dog.gameObject.SetActive(true);

    private void DisableObject(Dog dog) => dog.gameObject.SetActive(false);

    private void ReleaseObject(Dog dog) => dogPool.Release(dog);

    private void DestroyObject(Dog dog) => Destroy(dog);

    public bool CanInstantiate { get => canInstantiate; set => canInstantiate = value; }
}
