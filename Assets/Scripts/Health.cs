using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Text healthText;

    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField] private string gameOverSceneName;

    private void Start()
    {
        currentHealth = maxHealth; // sets curren health to max health on start up
    }

    private void Update()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth; // if the current health is more than the max health set current to max 

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // damage taking tracking to curent health
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure health never goes below 0
        healthText.text = "Health: " + currentHealth + "%"; // updates health text

        if (currentHealth <= 0)
        {
            // Player has died
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0; // Stops the game
        Cursor.lockState = CursorLockMode.None; // Unlock the mouse cursor
        SceneManager.LoadScene(gameOverSceneName);
    }
}