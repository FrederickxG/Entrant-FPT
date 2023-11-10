using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

   public float maxHealth = 100;
    public float currentHealth = 100;
    public float shieldHealth = 50;
    public float shieldRechargeTime = 30;
    private bool isBlocking = false;
    private float timeSinceLastBlocked = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isBlocking = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            isBlocking = false;
        }

        if (isBlocking)
        {
            timeSinceLastBlocked += Time.deltaTime;

            if (timeSinceLastBlocked >= shieldRechargeTime)
            {
                shieldHealth = 50;
                timeSinceLastBlocked = 0;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (isBlocking)
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
        else
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
    }
}
