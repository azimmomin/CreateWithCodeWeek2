using UnityEngine;

/// <summary>
/// This class is responsible for moving and
/// handling user input for the player.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private float minPlayerPositionZ = -9f;
    [SerializeField] private float maxPlayerPositionZ = -2f;
    [SerializeField] private int maxPlayerLives = 3;

    private float horizontalInput = 0f;
    private float verticalInput = 0f;

    private int remainingLives = 2;
    private int score = 0;

    private void Awake()
    {
        DetectCollisions.OnPlayerHit += DecreaseLife;
        DetectCollisions.OnPlayerMissed += DecreaseLife;
        AnimalHealth.OnAnimalFull += IncreaseScore;
    }

    private void DecreaseLife()
    {
        remainingLives -= 1;
    }

    private void IncreaseScore()
    {
        score += 10;
    }

    private void Update()
    {
        if (remainingLives < 0)
        {
            Debug.LogError($"Game Over! | Final Score: {score}");
            return;
        }

        DisplayScore();

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (horizontalInput * Time.deltaTime * speed));

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * (verticalInput * Time.deltaTime * speed));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition.y = projectilePrefab.transform.position.y;
            Instantiate(projectilePrefab, spawnPosition, projectilePrefab.transform.rotation);
        }
    }

    private void DisplayScore()
    {
        Debug.LogError($"Remaining Lives: {remainingLives} | Score: {score}");
    }

    private void LateUpdate()
    {
        Vector3 clampedPlayerPosition = transform.position;
        clampedPlayerPosition.z = Mathf.Clamp(clampedPlayerPosition.z, minPlayerPositionZ, maxPlayerPositionZ);
        transform.position = clampedPlayerPosition;
    }

    private void OnDestroy()
    {
        DetectCollisions.OnPlayerHit -= DecreaseLife;
        DetectCollisions.OnPlayerMissed -= DecreaseLife;
        AnimalHealth.OnAnimalFull -= IncreaseScore;
    }
}
