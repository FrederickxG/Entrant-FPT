using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damage);
}

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float health = 35f;
    public GameObject bloodEffectPrefab;
    public Vector3 bloodEffectOffset = new Vector3(1.5f, 1.5f, 0); 

    public void TakeDamage(float damage)
    {
        health -= damage;
        ShowBloodEffect(); // Show the blood effect when taking damage

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ShowBloodEffect()
    {
        if (bloodEffectPrefab != null)
        {
            // Instantiate the blood effect at the enemy's position with an offset
            GameObject bloodEffect = Instantiate(bloodEffectPrefab, transform.position + bloodEffectOffset, Quaternion.identity);
            bloodEffect.transform.SetParent(transform); // Make the blood effect follow the enemy
            Destroy(bloodEffect, 3f); // Destroy the blood effect after 5 seconds
        }
    }
}
