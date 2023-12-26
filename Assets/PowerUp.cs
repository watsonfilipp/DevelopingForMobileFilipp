using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float intervalMultiplier = 2f; //The multiplier to double the shooting interval
    public int damageMultiplier;

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
            shootingScript.DoubleDamage(damageMultiplier);
            Destroy(gameObject); //Destroy the power-up prefab after applying the effect
        }
    }
}
