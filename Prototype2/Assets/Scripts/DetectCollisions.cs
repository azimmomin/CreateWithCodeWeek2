using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Animal") && other.CompareTag("PlayerProjectile") ||
            gameObject.CompareTag("PlayerProjectile") && other.CompareTag("Animal"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (gameObject.CompareTag("GameOverTrigger") && other.CompareTag("Animal") ||
            gameObject.CompareTag("Animal") && other.CompareTag("GameOverTrigger"))
        {
            Debug.Log("Game Over");
        }
    }
}
