using UnityEngine;
using System.Collections;

public class SceneSequence : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject wakeUpCamera;
    public GameObject cutsceneCamera;
    public GameObject ad100Camera;
    public GameObject adrikArena;  // Adrik object to monitor
    public GameObject adrikLookBack;
    public GameObject ingaPerch;
    public GameObject ingaArena;
    public GameObject UI;
    public GameObject Freyaobj;
    public AudioSource wakeUpAudioSource;
    public AudioSource cutsceneAudioSource;
    public AudioSource ad100AudioSource;
    public AudioSource finalCutsceneAudioSource;
    public AudioSource lowHealthVoiceLine;
    public AudioSource criticalHealthVoiceLine;
    public GameManager gameManager; // Expose GameManager
    private bool adrikDestroyed = false; // Flag to track if Adrik is destroyed
    public EnemyHealth ingaHealth;
    public EnemyFollow ingaFollow;
    public Health playerHealth;
    public GameObject finalCam; // Reference to the final camera
    public GameObject ingaFinal; // Reference to the Inga final stage object
    public AudioSource finalVoiceLine; // Reference to the final voice line audio source

    private void Start()
    {
        // Start the sequence
        StartCoroutine(PlaySequence());
    }

    private IEnumerator PlaySequence()
    {
        // Step 1: Wake-up camera and audio
        UI.SetActive(false);
        Freyaobj.SetActive(true);
        wakeUpCamera.SetActive(true);
        mainCamera.SetActive(false);
        wakeUpAudioSource.Play();
        
        // Wait for wake-up audio to finish
        yield return new WaitForSeconds(wakeUpAudioSource.clip.length);

        // Step 2: Cutscene camera and audio
        Freyaobj.SetActive(false);
        wakeUpCamera.SetActive(false);
        cutsceneCamera.SetActive(true);
        cutsceneAudioSource.Play();

        // Wait for cutscene audio to finish
        yield return new WaitForSeconds(cutsceneAudioSource.clip.length);

        // Step 3: 100 AD camera and audio
        cutsceneCamera.SetActive(false);
        ad100Camera.SetActive(true);
        ad100AudioSource.Play();

        // Wait for 100 AD audio to finish
        yield return new WaitForSeconds(ad100AudioSource.clip.length);

        // Set the Adrik2 objective in GameManager
        if (gameManager != null)
        {
            gameManager.SetAdrik2Objective(); // Trigger Adrik2 sequence
        }

        // Step 4: Switch back to the main camera
        ad100Camera.SetActive(false);
        mainCamera.SetActive(true);
        UI.SetActive(true);

        // Activate Adrik arena and deactivate Adrik look back
        adrikArena.SetActive(true);
        adrikLookBack.SetActive(false);

        // Start checking for Adrik's destruction
        StartCoroutine(CheckForAdrikDestruction());
    }

    private IEnumerator CheckForAdrikDestruction()
    {
        // Wait until Adrik is destroyed (not found in the scene)
        while (!adrikDestroyed)
        {
            // Check if Adrik is still active in the scene
            if (adrikArena == null)
            {
                adrikDestroyed = true; // Set the flag
                AdrikDestroyed(); // Call method when Adrik is destroyed
                break; // Exit the loop
            }
            yield return null; // Wait for the next frame
        }
    }

    private void AdrikDestroyed()
    {
        // Step 5: Cutscene camera and audio
        UI.SetActive(false);
        mainCamera.SetActive(false);
        cutsceneCamera.SetActive(true);
        finalCutsceneAudioSource.Play();

        // Wait for cutscene audio to finish
        StartCoroutine(WaitForCutsceneEnd(finalCutsceneAudioSource.clip.length));
    }

    private IEnumerator WaitForCutsceneEnd(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Step 6: Switch back to the main camera
        cutsceneCamera.SetActive(false);
        mainCamera.SetActive(true);
        UI.SetActive(true);

        // Deactivate Inga perch and activate Inga arena
        ingaPerch.SetActive(false);
        ingaArena.SetActive(true);
    }

   public void OnIngaHealthDropsBelow300()
    {
        // Play voice line
        if (lowHealthVoiceLine != null)
        {
            lowHealthVoiceLine.Play();
        }

        // Make player invulnerable
        if (playerHealth != null)
        {
            playerHealth.SetInvulnerable(true);
            StartCoroutine(WaitForVoiceLineToEnd(lowHealthVoiceLine.clip.length));
        }

        // Increase Inga's speed
        if (ingaFollow != null)
        {
            ingaFollow.SetSpeed(53f);
        }
    }

    public void OnIngaHealthDropsBelow200()
    {
        // Play voice line
        if (criticalHealthVoiceLine != null)
        {
            criticalHealthVoiceLine.Play();
        }

        // Make player invulnerable
        if (playerHealth != null)
        {
            playerHealth.SetInvulnerable(true);
            StartCoroutine(WaitForVoiceLineToEnd(criticalHealthVoiceLine.clip.length));
        }

        // Increase Inga's damage
        if (ingaFollow != null)
        {
            ingaFollow.SetDamage(50);
        }
    }

    public void OnIngaHealthDropsBelow100()
    {

        // Switch to final camera and deactivate UI
        if (finalCam != null)
        {
            finalCam.SetActive(true);
            mainCamera.SetActive(false);
        }
        
        if (UI != null)
        {
            UI.SetActive(false);
        }

        // Deactivate Inga arena and activate Inga final stage
        if (ingaArena != null)
        {
            ingaArena.SetActive(false);
        }

        if (ingaFinal != null)
        {
            ingaFinal.SetActive(true);
        }

        // Play final voice line
        if (finalVoiceLine != null)
        {
            finalVoiceLine.Play();
            
        }

    }

    private IEnumerator WaitForFinalVoiceLineToEnd(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Switch back to main camera and activate UI
        if (finalCam != null)
        {
            finalCam.SetActive(false);
            mainCamera.SetActive(true);
        }

        if (UI != null)
        {
            UI.SetActive(true);
        }

         if (ingaArena != null)
        {
            ingaArena.SetActive(true);
        }

    }

    private IEnumerator WaitForVoiceLineToEnd(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Make player vulnerable again
        if (playerHealth != null)
        {
            playerHealth.SetInvulnerable(false);
        }
    }
}