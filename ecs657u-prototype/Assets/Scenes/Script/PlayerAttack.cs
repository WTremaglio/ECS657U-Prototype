using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1f;  // Range within which the player can hit a zombie
    public int attackDamage = 10;    // Damage dealt to the zombie

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Punch(); // Call the punch function when the space bar is pressed
        }
    }

    void Punch()
    {
        // Detect all colliders in the attack range
        Collider[] hitZombies = Physics.OverlapSphere(transform.position, attackRange);

        if (hitZombies.Length > 0)
        {
            Debug.Log("Punch attempt detected. Checking for zombies...");

            foreach (Collider collider in hitZombies)
            {
                if (collider.CompareTag("Zombie")) // Check if the collider is a zombie
                {
                    ZombieHealth zombieHealth = collider.GetComponent<ZombieHealth>();
                    if (zombieHealth != null)
                    {
                        zombieHealth.TakeDamage(attackDamage); // Apply damage to the zombie
                        Debug.Log($"Zombie punched! Damage dealt: {attackDamage}"); // Log damage info
                    }
                }
            }
        }
        else
        {
            Debug.Log("No zombies in range to punch.");
        }
    }

}

