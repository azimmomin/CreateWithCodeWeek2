﻿using UnityEngine;

public class DestroyIfOutOfBounds : MonoBehaviour
{
    private float leftLimit = -50f;
    private float bottomLimit = -5f;

    private void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}
