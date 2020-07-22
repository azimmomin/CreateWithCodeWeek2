using UnityEngine;

/// <summary>
/// This class is responsible for moving and
/// handling user input for the player.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject projectilePrefab = null;

    private float horizontalInput = 0f;
    // The fraction of the screen on the left and right
    // that the player is not allowed to move to.
    private float deadZoneFraction = 10f;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (horizontalInput * Time.deltaTime * speed));

        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
