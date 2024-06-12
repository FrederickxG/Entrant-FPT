using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IDamageable
{
    void TakeDamage(float damage);
}

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float health = 35f;
    public float maxHealth = 400f;
    public GameObject bloodEffectPrefab;
    public Vector3 bloodEffectOffset = new Vector3(1.5f, 1.5f, 0); 
    public GameStartSequence gameStartSequence;
    public SceneSequence sceneSequence;

    private float previousHealth; // To keep track of the previous health

    private void Start()
    {
        health = maxHealth; // Initialize health to maxHealth
        previousHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        ShowBloodEffect(); // Show the blood effect when taking damage

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            CheckHealthForEvents();
             CheckHealthForCutscene();
        }
    }

    private void CheckHealthForCutscene()
{
    if (health <= 100 && gameStartSequence != null)
    {
        gameStartSequence.StartCutscene(); // Start the cutscene when health reaches 100 and gameStartSequence is assigned
    }
}

    private void CheckHealthForEvents()
    {
        // Check if the health has dropped below each threshold and if it's crossed downward
        if (previousHealth > 300 && health <= 300 && sceneSequence != null)
        {
            sceneSequence.OnIngaHealthDropsBelow300();
        }
        else if (previousHealth > 200 && health <= 200 && sceneSequence != null)
        {
            sceneSequence.OnIngaHealthDropsBelow200();
        }
        else if (previousHealth > 100 && health <= 100 && sceneSequence != null)
        {
            sceneSequence.OnIngaHealthDropsBelow100();
        }

        // Update previous health
        previousHealth = health;
    }

    void ShowBloodEffect()
    {
        if (bloodEffectPrefab != null)
        {
            // Instantiate the blood effect at the enemy's position with an offset
            GameObject bloodEffect = Instantiate(bloodEffectPrefab, transform.position + bloodEffectOffset, Quaternion.identity);
            bloodEffect.transform.SetParent(transform); // Make the blood effect follow the enemy
            Destroy(bloodEffect, 3f); // Destroy the blood effect after 3 seconds
        }
    }
}
