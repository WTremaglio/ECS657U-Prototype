using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 50;  // Maximum health for zombies
    private int currentHealth;    // Current health

    void Start()
    {
        currentHealth = maxHealth; // Initialize health to maximum
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Subtract damage from current health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0

        if (currentHealth <= 0)
        {
            Die(); // Handle zombie death
        }
    }

    void Die()
    {
        Debug.Log("Zombie has died!");
        Destroy(gameObject); // Destroy the zombie GameObject
    }
}



