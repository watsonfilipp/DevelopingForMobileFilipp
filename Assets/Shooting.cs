using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 10f; 
    public float shootingInterval = 2f; //The interval between shots in seconds
    public float bulletLifespan = 3f; //Bullet dies overtime
    public int bulletDamage = 1; //The damage amount
   

    void Start()
    {
        InvokeRepeating("Shoot", 0f, shootingInterval);
    }

    void Update()
    {
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = shootingPoint.forward * bulletSpeed;
        Destroy(bullet, bulletLifespan);

    }

    //OnTriggerEnter is called when the Collider other enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    //OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
    void OnCollisionEnter(Collision collision)
    {
        
        HandleCollision(collision.gameObject);

    }

    void HandleCollision(GameObject otherGameObject)
    {
        
        if (otherGameObject.CompareTag("Target"))
        {
            DealDamage(otherGameObject);//Apply damage to the target


        }
    }

    void DealDamage(GameObject target)
    {
        Health health = target.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(bulletDamage);
        }
    }

    public void DoubleShootingInterval(float multiplier)
    {
        shootingInterval *= multiplier;
        CancelInvoke("Shoot"); // Cancel the previous shooting interval
        InvokeRepeating("Shoot", 0f, shootingInterval);
    }

    public void IncreaseDamage(int amount)
    {
        bulletDamage += amount;
    }

    

}

