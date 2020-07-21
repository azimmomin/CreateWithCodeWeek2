using UnityEngine;

public class DestroyIfOutOfBounds : MonoBehaviour
{
    [SerializeField] private float topBound = 30f;
    [SerializeField] private float bottomBound = -20f;
    private void Update()
    {
        if (transform.position.z > topBound || transform.position.z < bottomBound)
            Destroy(gameObject);
    }
}