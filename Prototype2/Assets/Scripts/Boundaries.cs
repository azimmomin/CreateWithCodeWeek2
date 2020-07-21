using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Renderer objRenderer;
    [SerializeField] private bool boundX = false;
    [SerializeField] private bool boundY = false;

    private Vector2 screenBounds = Vector2.zero;
    private Vector2 objectBounds = Vector2.zero;

    private void Start()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectBounds.x = objRenderer.bounds.extents.x;
        objectBounds.y = objRenderer.bounds.extents.y;
    }

    private void LateUpdate()
    {
        Vector3 clampedPosition = transform.position;
        if (boundX)
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -screenBounds.x + objectBounds.x, screenBounds.x - objectBounds.x);

        if (boundY)
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -screenBounds.y + objectBounds.y, screenBounds.y - objectBounds.y);

        transform.position = clampedPosition;
    }
}
