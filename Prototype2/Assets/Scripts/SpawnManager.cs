using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnableAnimals = null;
    [SerializeField] private float spawnRangeX = 10f;
    [SerializeField] private float spawnRangeZ = 8f;

    [SerializeField] private float spawnPosLeft = -15f;
    [SerializeField] private float spawnPosRight = 15f;
    [SerializeField] private float spawnPosTop = 20f;

    [SerializeField] private float spawnStartDelay = 2f;
    [SerializeField] private float spawnInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnAnimalInRandomPosition", spawnStartDelay, spawnInterval);
    }

    private void SpawnAnimalInRandomPosition()
    {
        int roll = Random.Range(0, 3);
        switch (roll)
        {
            case 0:
                SpawnRandomAnimalTop();
                break;
            case 1:
                SpawnRandomAnimalLeft();
                break;
            case 2:
                SpawnRandomAnimalRight();
                break;
        }
    }

    private void SpawnRandomAnimalTop()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0f, spawnPosTop);
        SpawnAnimalForPositionAndRotation(spawnPosition, 180f);
    }

    private void SpawnRandomAnimalLeft()
    {
        Vector3 spawnPosition = new Vector3(spawnPosLeft, 0f, Random.Range(-spawnRangeZ, spawnRangeZ));
        SpawnAnimalForPositionAndRotation(spawnPosition, 90f);
    }

    private void SpawnRandomAnimalRight()
    {
        Vector3 spawnPosition = new Vector3(spawnPosRight, 0f, Random.Range(-spawnRangeZ, spawnRangeZ));
        SpawnAnimalForPositionAndRotation(spawnPosition, 270f);
    }

    private void SpawnAnimalForPositionAndRotation(Vector3 spawnPosition, float yRotation)
    {
        // TODO: Bound spawn position to screen.
        int index = Random.Range(0, spawnableAnimals.Length);
        Vector3 spawnRotation = spawnableAnimals[index].transform.rotation.eulerAngles;
        spawnRotation.y = yRotation;
        Instantiate(spawnableAnimals[index], spawnPosition, Quaternion.Euler(spawnRotation));
    }
}