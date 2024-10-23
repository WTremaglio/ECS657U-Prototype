using UnityEngine;

public class ZombieChase : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float stoppingDistance = 1.5f;
    public int damageToPlayer = 10; // Damage dealt to player
    private float attackCooldown = 1f; // Time between attacks
    private float lastAttackTime = 0f; // Time of last attack

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > stoppingDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
                transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            }
            else
            {
                // Attack the player if in range and cooldown is over
                if (Time.time > lastAttackTime + attackCooldown)
                {
                    lastAttackTime = Time.time;
                    HealthManager playerHealth = player.GetComponent<HealthManager>();
                    if (playerHealth != null)
                    {
                        playerHealth.healthAmount -= damageToPlayer; // Damage the player
                        playerHealth.UpdateHealthBar(); // Update the health bar
                    }
                }
            }
        }
    }
}


