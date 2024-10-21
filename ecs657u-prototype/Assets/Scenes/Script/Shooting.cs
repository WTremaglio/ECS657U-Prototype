using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab of the projectile
    public float shootForce = 500f;      // Force applied to shoot the projectile

    void Update()
    {
        // Check for spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create a projectile (sphere)
        GameObject projectile = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // Set position in front of the player
        projectile.transform.position = transform.position + transform.forward * 1.5f;

        // Add a Rigidbody to the projectile for physics interaction
        Rigidbody rb = projectile.AddComponent<Rigidbody>();

        // Apply a force to shoot the projectile
        rb.AddForce(transform.forward * shootForce);

        // Optionally, destroy the projectile after a few seconds to clean up the scene
        Destroy(projectile, 5f);
    }
}
