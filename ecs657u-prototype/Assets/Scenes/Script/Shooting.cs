using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;  
    public float shootForce = 500f;    

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
     
        GameObject projectile = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        
        projectile.transform.position = transform.position + transform.forward * 1.5f;

       
        Rigidbody rb = projectile.AddComponent<Rigidbody>();

       
        rb.AddForce(transform.forward * shootForce);

       
        Destroy(projectile, 5f);
    }
}
