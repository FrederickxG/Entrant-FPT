using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    public Blocking PlayerHealthScript;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerHealthScript.isBlocking = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            PlayerHealthScript.isBlocking = false;
        }
    }

    public void TakeDamage(float damage)
    {
        PlayerHealthScript.TakeDamage(damage);
    }

    private void Die()
    {
        Debug.Log("Player has died!");
    }
}

