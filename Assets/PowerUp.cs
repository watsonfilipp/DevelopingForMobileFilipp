using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float intervalMultiplier = 2f; //The multiplier to double the shooting interval

    //OnTriggerEnter is called when the Collider other enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPowerUp(other.gameObject);
        }
    }

    void ApplyPowerUp(GameObject player)
    {
        Shooting shootingScript = player.GetComponent<Shooting>();

        if (shootingScript != null)
        {
            shootingScript.DoubleShootingInterval(intervalMultiplier);
            Destroy(gameObject); //Destroy the power-up prefab after applying the effect
        }
    }
}
