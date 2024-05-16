using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Image healthBarImage; // Reference to the Image component
    public int maxHealth = 100;
    public int currentHealth;
    public DamageIndicator damageIndicator;
    [SerializeField] private string gameOverSceneName;
    public AudioSource damageSound;
    [SerializeField] private AudioClip[] hurtSounds;

    private void Start()
    {
        currentHealth = maxHealth; // Sets current health to max health on start up
        UpdateHealthBar(); // Initialize health bar
    }

    private void Update()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth; // If the current health is more than the max health set current to max
    }

    public void TakeDamage(int damage)
    {
        damageIndicator.ShowDamageIndicator();
        currentHealth -= damage; // Subtract damage from current health
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure health never goes below 0
        UpdateHealthBar(); // Update health bar
        damageSound.clip = hurtSounds[Random.Range(0, hurtSounds.Length)];
        damageSound.Play();

        if (currentHealth <= 0)
        {
            // Player has died
            GameOver();
        }
    }

    void UpdateHealthBar()
    {
        healthBarImage.fillAmount = (float)currentHealth / maxHealth; // Update the fill amount of the health bar image
    }

    void GameOver()
    {
        Time.timeScale = 0; // Stops the game
        Cursor.lockState = CursorLockMode.None; // Unlock the mouse cursor
        SceneManager.LoadScene(gameOverSceneName);
    }
}
