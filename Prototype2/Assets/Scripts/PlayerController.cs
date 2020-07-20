using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private float horizontalInput = 0f;
    // The fraction of the screen on the left and right
    // that the player is not allowed to move to.
    private float deadZoneFraction = 10f;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (horizontalInput * Time.deltaTime * speed));
    }

    private void LateUpdate()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        playerScreenPosition.x = Mathf.Clamp(
            playerScreenPosition.x,
            Screen.width / deadZoneFraction,
            Screen.width - (Screen.width / deadZoneFraction)
        );

        transform.position = Camera.main.ScreenToWorldPoint(playerScreenPosition);
    }
}
