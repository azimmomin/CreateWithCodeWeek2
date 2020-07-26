using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float minSpawnInterval = 3.0f;
    private float maxSpawnInterval = 5.0f;

    private float nextSpawnTime = 0f;

    private void Start()
    {
        nextSpawnTime = Time.realtimeSinceStartup + startDelay;
    }

    private void Update()
    {
        if (Time.realtimeSinceStartup >= nextSpawnTime)
        {
            SpawnRandomBall();
            nextSpawnTime = Time.realtimeSinceStartup + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }
}
