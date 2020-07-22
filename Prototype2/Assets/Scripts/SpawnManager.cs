using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnableAnimals;
    [SerializeField] private float spawnRangeX = 20f;
    [SerializeField] private float spawnPosZ = 20f;
    [SerializeField] private float spawnStartDelay = 2f;
    [SerializeField] private float spawnInterval = 1.5f;
    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", spawnStartDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        int index = Random.Range(0, spawnableAnimals.Length);
        // TODO: Bound this to the screen.
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0f, spawnPosZ);
        Instantiate(spawnableAnimals[index], spawnPosition, spawnableAnimals[index].transform.rotation);
    }
}