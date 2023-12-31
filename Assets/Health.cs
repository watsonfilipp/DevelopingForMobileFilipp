using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        healthText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateHealthText();
    }

    // Applying damage to the target
    public void TakeDamage(int damage)
    {
        Debug.Log("Taking Damage. Current Health: " + currentHealth + ", Damage: " + damage);
        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);

        if (currentHealth <= 0)
        {
            Die(); //Target death condition
        }

        UpdateHealthText();
    }

    //Target death method
    void Die()
    {
        Destroy(gameObject); // Particles point to apply
    }

    // Destroying the bullet when hitting the target and taking damage
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

    // Update the health display on the TextMeshPro element
    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }
}
