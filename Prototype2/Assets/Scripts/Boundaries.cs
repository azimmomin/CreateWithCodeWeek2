using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [SerializeField] private bool boundX = false;
    [SerializeField] private bool boundY = false;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        Vector3 clampedPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (boundX)
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, 0, Screen.width);

        if (boundY)
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, 0, Screen.height);

        transform.position = mainCamera.ScreenToWorldPoint(clampedPosition);
    }
}
