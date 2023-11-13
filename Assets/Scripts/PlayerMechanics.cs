using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMechanics : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int blockHealth = 50;
    public bool isBlocking;
    public GameObject block;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Blocking mechanics
        if (Input.GetKey(KeyCode.E))
        {
            if (!isBlocking)
            {
                isBlocking = true;
                StartCoroutine(Block());
            }
        }
        else
        {
            isBlocking = false;
        }

        // Health regeneration
        if (currentHealth < maxHealth)
        {
            currentHealth += 1;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isBlocking)
        {
            block.GetComponent<Block>().TakeDamage(damage);
        }
        else
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                // Player dies
            }
        }
    }

    IEnumerator Block()
    {
        if (block == null)
        {
            block = Instantiate(Resources.Load("Block") as GameObject, transform.position, Quaternion.identity);
        }
        else
        {
            block.SetActive(true);
        }

        while (isBlocking)
        {
            yield return null;
        }

        if (block != null)
        {
            block.SetActive(false);
        }
    }
}