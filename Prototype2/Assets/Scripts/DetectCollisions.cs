using System;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public static Action OnPlayerHit;
    public static Action OnPlayerMissed;

    public static Action OnAnimalFed;

    private void OnTriggerEnter(Collider other)
    {

        if (gameObject.CompareTag("Animal") && other.CompareTag("GameOverTrigger"))
        {
            OnPlayerMissed?.Invoke();
        }
        else if (gameObject.CompareTag("Animal") && other.CompareTag("Player"))
        {
            OnPlayerHit?.Invoke();
        }
    }
}
