using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 10f;
    public float shootingInterval = 2f; // The interval between shots in seconds
    public float bulletLifespan = 3f; // Bullet dies over time
    public int bulletDamage = 5; // The damage amount

    public TextMeshProUGUI damageText; // Reference to the TextMeshProUGUI component for bullet damage
    public TextMeshProUGUI intervalText; // Reference to the TextMeshProUGUI component for shooting interval

    void Start()
    {
        InvokeRepeating("Shoot", 0f, shootingInterval);
    }

    void Update()
    {
        // You can add update logic here if needed

        // Update the damage text on the canvas
        if (damageText != null)
        {
            damageText.text = "Bullet Damage: " + bulletDamage;
        }

        // Update the interval text on the canvas
        if (intervalText != null)
        {
            intervalText.text = "Interval: " + shootingInterval + "sec";
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        // Set bullet damage before shooting
        if (bulletScript != null)
        {
            bulletScript.SetBulletDamage(bulletDamage);
        }

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = shootingPoint.forward * bulletSpeed;
        Destroy(bullet, bulletLifespan);
    }

    void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }

    void HandleCollision(GameObject otherGameObject)
    {
        if (otherGameObject.CompareTag("Target"))
        {
            DealDamage(otherGameObject); // Apply damage to the target
        }
    }

    void DealDamage(GameObject target)
    {
        Health health = target.GetComponent<Health>();

        if (health != null)
        {
            Debug.Log("Bullet Damage: " + bulletDamage);
            health.TakeDamage(bulletDamage);
        }
    }

    public void DoubleShootingInterval(float multiplier)
    {
        shootingInterval *= multiplier;
        CancelInvoke("Shoot"); // Cancel the previous shooting interval
        InvokeRepeating("Shoot", 0f, shootingInterval);

        // Update the interval text on the canvas after changing shooting interval
        if (intervalText != null)
        {
            intervalText.text = "Interval: " + shootingInterval + "sec";
        }
    }

    public void DoubleDamage(int multiplier)
    {
        bulletDamage *= multiplier;
        CancelInvoke("Shoot"); // Cancel the previous shooting interval
        InvokeRepeating("Shoot", 0f, shootingInterval);

        // Update the damage text on the canvas after changing bullet damage
        if (damageText != null)
        {
            damageText.text = "Damage: " + bulletDamage;
        }

        // Update the interval text on the canvas after changing shooting interval
        if (intervalText != null)
        {
            intervalText.text = "Interval: " + shootingInterval + "sec";
        }
    }

    public void IncreaseDamage(int amount)
    {
        bulletDamage += amount;

        // Update the damage text on the canvas after increasing bullet damage
        if (damageText != null)
        {
            damageText.text = "Damage: " + bulletDamage;
        }
    }
}
