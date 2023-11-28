using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMechanics : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    
     void Start()
    {
        currentHealth = maxHealth;
    }

     public void TakeDamage(int damage)
    {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                // Player has died
            }
        }
}

    
    
