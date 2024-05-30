using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameStartSequence : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject alternateCamera;
    public GameObject cutsceneCamera;
    public GameObject comsDevice;
    public AudioSource startAudioSource;
    public GameObject adrikArena;
    public GameObject adrikPause;
    public GameObject adrikPerch;
    public GameObject adrikLethal;
    public GameObject uiPanel;
    public EnemyHealth enemyHealth;
    public AudioSource cutsceneAudioSource;
    public GameObject blurEffect; 
    public AudioSource blurSoundSource; 
    public AudioSource adrikLethalSoundSource; 

    private void Start()
    {
        // Deactivate UI panel
        uiPanel.SetActive(false);

        // Switch to alternate camera
        mainCamera.SetActive(false);
        alternateCamera.SetActive(true);

        // Activate coms device
        comsDevice.SetActive(true);

        // Play start audio
        startAudioSource.Play();

        // Start the coroutine to handle the rest of the sequence after the audio clip ends
        StartCoroutine(SequenceAfterAudioClip());
    }

    private IEnumerator SequenceAfterAudioClip()
    {
        // Wait for the audio clip to finish playing
        yield return new WaitForSeconds(startAudioSource.clip.length);

        // Set Adrik arena to active
        adrikArena.SetActive(true);

        // Deactivate Adrik perch
        adrikPerch.SetActive(false);

        // Deactivate coms device
        comsDevice.SetActive(false);

        // Switch back to the main camera
        alternateCamera.SetActive(false);
        mainCamera.SetActive(true);

        // Activate UI panel
        uiPanel.SetActive(true);
    }

    // Method to start the cutscene
    public void StartCutscene()
    {
        StartCoroutine(CutsceneSequence());
    }

    private IEnumerator CutsceneSequence()
    {
        // Deactivate UI panel
        uiPanel.SetActive(false);

        // Deactivate Adrik Arena/ set pause
        adrikArena.SetActive(false);
        adrikPause.SetActive(true);

        // Switch to cutscene camera
        mainCamera.SetActive(false);
        cutsceneCamera.SetActive(true);

        // Play cutscene audio
        cutsceneAudioSource.Play();

        // Wait for the audio clip to finish
        yield return new WaitForSeconds(cutsceneAudioSource.clip.length);

        // Activate blur effect and play blur sound
        blurEffect.SetActive(true);
        blurSoundSource.Play();

        // Wait for blur sound to finish
        yield return new WaitForSeconds(blurSoundSource.clip.length);

        // Deactivate blur effect
        blurEffect.SetActive(false);

        // Activate AdrikLethal and play its sound
        adrikLethal.SetActive(true);
        adrikLethalSoundSource.Play();

        // Wait for AdrikLethal sound to finish
        yield return new WaitForSeconds(adrikLethalSoundSource.clip.length);

        // Load the "training" level
        SceneManager.LoadScene("training");
    }
}
