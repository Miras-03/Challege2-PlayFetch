using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField] DogSpawner dogSpawner;

    private void Update() => CheckOrInstantiate();

    private void CheckOrInstantiate()
    {
        if (Input.GetKeyUp(KeyCode.Space) && dogSpawner.CanInstantiate)
        {
            dogSpawner.CanInstantiate = false;
            dogSpawner.SpawnWithDelay();
        }
    }
}