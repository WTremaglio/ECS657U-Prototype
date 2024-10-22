using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionDetector : MonoBehaviour
{
    public float healAmount = 10f; 

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.Heal(healAmount); 
                Debug.Log("Healing player: " + healAmount);
                Destroy(gameObject); 
            }
        }
    }
}

