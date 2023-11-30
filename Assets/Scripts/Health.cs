using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText;

    public int maxHealth = 100;
    public int currentHealth;
    float lerpSpeed;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;

    }

    public void TakeDamage(int damage)
{
    currentHealth -= damage;
    currentHealth = Mathf.Max(currentHealth, 0); // Ensure health never goes below 0
    healthText.text = "Health: " + currentHealth + "%";

    if (currentHealth <= 0)
    {
        // Player has died
        GameOver();
    }
}
    void GameOver()
    {
        Time.timeScale = 0; // Stops the game
        Debug.Log("Game Over"); // Prints Game Over in the console
    }
}