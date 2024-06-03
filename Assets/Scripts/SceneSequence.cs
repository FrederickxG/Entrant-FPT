using UnityEngine;
using System.Collections;

public class SceneSequence : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject wakeUpCamera;
    public GameObject cutsceneCamera;
    public GameObject ad100Camera;
    public GameObject adrikArena;
    public GameObject adrikLookBack;
    public GameObject ingaPerch;
    public GameObject ingaArena;
    public GameObject UI;
    public AudioSource wakeUpAudioSource;
    public AudioSource cutsceneAudioSource;
    public AudioSource ad100AudioSource;
    public AudioSource finalCutsceneAudioSource;

    public GameManager gameManager; // Expose GameManager

    private void Start()
    {
        // Start the sequence
        StartCoroutine(PlaySequence());
    }

    private IEnumerator PlaySequence()
    {
        // Step 1: Wake-up camera and audio
        UI.SetActive(false);
        wakeUpCamera.SetActive(true);
        mainCamera.SetActive(false);
        wakeUpAudioSource.Play();
        
        // Wait for wake-up audio to finish
        yield return new WaitForSeconds(wakeUpAudioSource.clip.length);

        // Step 2: Cutscene camera and audio
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
    }

    // Method to be called when Adrik arena is destroyed
    public void OnAdrikArenaDestroyed()
    {
        StartCoroutine(HandleAdrikArenaDestruction());
    }

    private IEnumerator HandleAdrikArenaDestruction()
    {
        // Step 5: Cutscene camera and audio
        mainCamera.SetActive(false);
        cutsceneCamera.SetActive(true);
        finalCutsceneAudioSource.Play();

        // Wait for cutscene audio to finish
        yield return new WaitForSeconds(finalCutsceneAudioSource.clip.length);

        // Step 6: Switch back to the main camera
        cutsceneCamera.SetActive(false);
        mainCamera.SetActive(true);

        // Deactivate Inga perch and activate Inga arena
        ingaPerch.SetActive(false);
        ingaArena.SetActive(true);
    }
}
