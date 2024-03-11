using UnityEngine;

public class EnemyDestroyHandler : MonoBehaviour
{
    public GameObject adrikEnemy; // Reference to the Adrik enemy GameObject
    public GameObject door1;
    public GameObject door2;
    public GameObject enemyHolder;
    public AudioSource audioSource;

    private bool adrikDestroyed = false; // Flag to track if the Adrik enemy is destroyed

    private void Start()
    {
        // Ensure all required references are assigned
        if (adrikEnemy == null || door1 == null || door2 == null || enemyHolder == null || audioSource == null)
        {
            Debug.LogError("One or more references are not assigned!");
            enabled = false; // Disable the script
        }
    }

    private void Update()
    {
        // Check if the Adrik enemy is destroyed
        if (adrikEnemy == null && !adrikDestroyed)
        {
            // Play the audio source
            audioSource.Play();

            // Set door 1 inactive
            door1.SetActive(false);

            // Set door 2 active
            door2.SetActive(true);

            // Set the enemy holder active
            enemyHolder.SetActive(true);

            // Set the flag to true
            adrikDestroyed = true;
        }
    }
}
