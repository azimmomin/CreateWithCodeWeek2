using UnityEngine;

public class DestroyIfOutOfBounds : MonoBehaviour
{
    [SerializeField] private Vector2 boundsOffset = Vector2.zero;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        boundsOffset = mainCamera.WorldToScreenPoint(boundsOffset);
    }

    private void Update()
    {
        Vector3 posInScreenCoords = mainCamera.WorldToScreenPoint(transform.position);
        if (posInScreenCoords.x > Screen.width + boundsOffset.x ||
            posInScreenCoords.x < -boundsOffset.x ||
            posInScreenCoords.y > Screen.height + boundsOffset.y ||
            posInScreenCoords.y < -boundsOffset.y)
        {
            Destroy(gameObject);
        }
    }
}