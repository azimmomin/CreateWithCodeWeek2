using UnityEngine;

/// <summary>
/// Moves the object this script is attached to
/// forwards at the specified speed.
/// </summary>
public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 40f;

    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
    }
}