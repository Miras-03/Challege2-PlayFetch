using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] ballPrefabs;

    private const int spawnLimitXLeft = -30;
    private const int spawnLimitXRight = 0;
    private const int spawnPosY = 30;

    private const int startDelay = 2;
    private const int spawnInterval = 4;

    private void Start() => InvokeRepeating(nameof(SpawnRandomBall), startDelay, spawnInterval);

    private void SpawnRandomBall()
    {
        int rand = Random.Range(0, 3);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        Instantiate(ballPrefabs[rand], spawnPos, ballPrefabs[0].transform.rotation);
    }
}
