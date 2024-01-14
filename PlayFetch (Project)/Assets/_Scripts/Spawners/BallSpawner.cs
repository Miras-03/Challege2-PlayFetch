using UnityEngine;
using UnityEngine.Pool;

public sealed class BallSpawner : MonoBehaviour
{
    public Ball ball;
    private ObjectPool<Ball> pool;

    private const int spawnLimitXLeft = -30;
    private const int spawnLimitXRight = 0;
    private const int spawnPosY = 30;
    private const int startDelay = 2;
    private const int spawnInterval = 4;

    private void Awake() =>
        pool = new ObjectPool<Ball>(CreateObject, EnableObject, DisableObject, DestroyObject,
            collectionCheck: false,
            maxSize: 10);

    private void Start() => InvokeRepeating(nameof(SpawnRandomBall), startDelay, spawnInterval);

    private void SpawnRandomBall()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        Ball obj = pool.Get();
        obj.transform.position = spawnPos;
        obj.Init(ReleaseObject);
    }

    private Ball CreateObject() => Instantiate(ball, transform);

    private void EnableObject(Ball obj) => obj.gameObject.SetActive(true);

    private void DisableObject(Ball obj) => obj.gameObject.SetActive(false);

    private void ReleaseObject(Ball obj) => pool.Release(obj);

    private void DestroyObject(Ball obj) => Destroy(obj.gameObject);
}