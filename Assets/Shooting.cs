using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 10f;
    public float shootingInterval = 2f; // The interval between shots in seconds
    public float bulletLifespan = 3f; // Bullet dies over time
    public int bulletDamage = 5; // The damage amount

    void Start()
    {
        InvokeRepeating("Shoot", 0f, shootingInterval);
    }

    void Update()
    {
        // You can add update logic here if needed
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
    }
    public void DoubleDamage(int multiplier)
    {
        bulletDamage *= multiplier;
        CancelInvoke("Shoot"); // Cancel the previous shooting interval
        InvokeRepeating("Shoot", 0f, shootingInterval);
    }
    public void IncreaseDamage(int amount)
    {
        bulletDamage += amount;
    }
}
