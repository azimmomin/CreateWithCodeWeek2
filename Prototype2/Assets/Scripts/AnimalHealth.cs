using System;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHealth : MonoBehaviour
{
    public static Action OnAnimalFull;

    [SerializeField] private float maxHealth    = 30f;
    [SerializeField] private Slider healthMeter = null;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthMeter.value = currentHealth / maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Animal") && other.CompareTag("PlayerProjectile"))
        {
            currentHealth -= 10f;
            Destroy(other.gameObject);
        }

        if (currentHealth <= 0f)
        {
            OnAnimalFull?.Invoke();
            Destroy(gameObject);
        }
    }
}
