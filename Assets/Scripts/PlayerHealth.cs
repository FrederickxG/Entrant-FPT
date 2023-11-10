using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    public float shieldHealth = 50;
    public float shieldRechargeTime = 30;
    private float timeSinceLastBlocked = 0;
    private bool isBlocking = false;

    void Update()
    {
        timeSinceLastBlocked += Time.deltaTime;

        if (timeSinceLastBlocked >= shieldRechargeTime)
        {
            if (shieldHealth < maxHealth)
            {
                shieldHealth += Time.deltaTime;
            }

            if (shieldHealth > maxHealth)
            {
                shieldHealth = maxHealth;
            }

            timeSinceLastBlocked = 0;
        }

        // Check if the E key is being held down
        if (Input.GetKey(KeyCode.E))
        {
            isBlocking = true;
        }
        else
        {
            isBlocking = false;
        }

        // Update the current health based on the shield health
        currentHealth = Mathf.Max(maxHealth - shieldHealth, 0);
    }

    public void TakeDamage(float damage)
    {
        if (!isBlocking)
        {
            shieldHealth -= damage;

            if (shieldHealth <= 0)
            {
                currentHealth -= damage;

                if (currentHealth <= 0)
                {
                    Die();
                }
            }
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
    }
}