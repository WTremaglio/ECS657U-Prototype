using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float healthAmount = 100f; // Starting health
    public Image healthBar; // Reference to the health bar UI

    void Start()
    {
        UpdateHealthBar();
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100); // Ensure health does not exceed 100
        UpdateHealthBar();
        Debug.Log("Healed to: " + healthAmount); // Log new health amount
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = healthAmount / 100f; // Update the health bar UI
        }
    }
}
