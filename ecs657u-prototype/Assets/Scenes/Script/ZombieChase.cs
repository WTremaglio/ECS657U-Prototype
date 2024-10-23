
using System.Collections;
using System.Collections.Generic;
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
        // Chase player logic remains the same
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > stoppingDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
                transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
{
    Debug.Log("Zombie collided with: " + collision.gameObject.name); 
    
    if (collision.gameObject.CompareTag("Player")) // Check if the collided object is the player
    {
        HealthManager playerHealth = collision.gameObject.GetComponent<HealthManager>();
        
        if (playerHealth != null && Time.time > lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time; // Update attack time

            // Decrease player's health
            playerHealth.healthAmount -= damageToPlayer;
            playerHealth.UpdateHealthBar();

            Debug.Log("Player health reduced to: " + playerHealth.healthAmount); 
        }
    }
}
}