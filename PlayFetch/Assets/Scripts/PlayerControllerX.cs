using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float coolDownTimeInSeconds = 1.5f;
    private float lastFireTime = 0f;

    private void Update()
    {
        // On spacebar press, send dog. We have a cooldown so the player
        // can not spam the spacebar.
        if (!IsCoolingDown() && Input.GetKeyDown(KeyCode.Space))
        {
            lastFireTime = Time.realtimeSinceStartup;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }

    private bool IsCoolingDown()
    {
        return Time.realtimeSinceStartup < (lastFireTime + coolDownTimeInSeconds);
    }
}
