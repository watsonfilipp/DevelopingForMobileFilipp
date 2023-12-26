using UnityEngine;
using TMPro;
public class PlayerCopy : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    private GameObject instantiatedPrefab;

    public float smoothness = 5f;

    public int maxHealth = 100;  //This script has its own separate health in this script (not health script)!
    private int currentHealth;

    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;


        healthText = GetComponentInChildren<TextMeshProUGUI>();


        UpdateHealthText();
    }

    //Applying damage to the iceberg
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthText();
    }

    //Iceberg death method
    void Die()
    {
        InstantiatePrefabNextToPlayer();
        Destroy(gameObject); //Particles point to apply
    }

    //Destroying the bullet when hitting the target and taking damage
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            // Extracting bullet damage from the bullet itself
            Bullet bullet = other.GetComponent<Bullet>();

            if (bullet != null)
            {
                TakeDamage(bullet.GetBulletDamage());
            }

            Destroy(other.gameObject);
        }
    }

    //Update the health display on the TextMeshPro element
    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }
    

    void InstantiatePrefabNextToPlayer()
    {
        //Get the position of the player
        Vector3 playerPosition = transform.position;

        //Calculate a new position next to the player with the same Y and Z positions
        Vector3 newPosition = new Vector3(playerPosition.x + 1f, playerPosition.y, playerPosition.z);

        //Instantiate the prefab at the new position
        instantiatedPrefab = Instantiate(prefabToInstantiate, newPosition, Quaternion.identity);

    }

   
}
