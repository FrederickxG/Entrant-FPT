using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public PlayerBlock playerBlock; // Reference to the PlayerBlock script for checking if the player is blocking

    public Image healthBarImage; // Reference to the Image component for the health bar
    public float maxHealth = 100f;
    public float currentHealth;
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

    public void TakeDamage(float damage)
{
    // Check if the player is currently blocking
    if (playerBlock != null && playerBlock.IsBlocking())
    {
        // Player is blocking, reduce or negate damage
        // For example, reduce damage to zero
        damage = 0f;
    }
    else
    {
        // Player is not blocking, apply damage
        damageIndicator.ShowDamageIndicator(); // Show damage indicator
        PlayHurtSound(); // Play hurt sound
    }

    currentHealth -= damage; // Subtract damage from current health
    currentHealth = Mathf.Max(currentHealth, 0); // Ensure health never goes below 0
    UpdateHealthBar(); // Update health bar

    if (currentHealth <= 0)
    {
        // Player has died
        GameOver();
    }
}


    void UpdateHealthBar()
    {
        // Update the fill amount of the health bar image based on current health
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = currentHealth / maxHealth;
        }
    }

    void PlayHurtSound()
    {
        // Play a random hurt sound from the array of hurt sounds
        if (damageSound != null && hurtSounds.Length > 0)
        {
            damageSound.clip = hurtSounds[Random.Range(0, hurtSounds.Length)];
            damageSound.Play();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0; // Stops the game
        Cursor.lockState = CursorLockMode.None; // Unlock the mouse cursor
        SceneManager.LoadScene(gameOverSceneName); // Load the game over scene
    }
}
