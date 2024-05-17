using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStartSequence : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject alternateCamera;
    public GameObject cutsceneCamera;
    public GameObject comsDevice;
    public GameObject audioClipObject;
    public AudioClip startAudioClip;
    public GameObject adrikArena;
    public GameObject adrikPause;
    public GameObject adrikPerch;
    public GameObject uiPanel;
    public EnemyHealth enemyHealth; 
    public AudioClip cutsceneAudioClip; 

    private AudioSource audioSource;

    private void Start()
    {
        // Deactivate UI panel
        uiPanel.SetActive(false);

        // Switch to alternate camera
        mainCamera.SetActive(false);
        alternateCamera.SetActive(true);

        // Activate coms device
        comsDevice.SetActive(true);

        // Play audio clip
        audioSource = audioClipObject.AddComponent<AudioSource>();
        audioSource.clip = startAudioClip;
        audioSource.Play();

        // Start the coroutine to handle the rest of the sequence after the audio clip ends
        StartCoroutine(SequenceAfterAudioClip());
    }

    private IEnumerator SequenceAfterAudioClip()
    {
        // Wait for the audio clip to finish playing
        yield return new WaitForSeconds(startAudioClip.length);

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
        audioSource.clip = cutsceneAudioClip;
        audioSource.Play();

        // Wait for the audio clip to finish
        yield return new WaitForSeconds(cutsceneAudioClip.length);

        // Switch back to the main camera 
        cutsceneCamera.SetActive(false);
        mainCamera.SetActive(true);
    }
}
