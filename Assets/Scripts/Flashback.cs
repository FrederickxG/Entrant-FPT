using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flashback : MonoBehaviour
{
    public AudioSource initialAudio;
    public GameObject[] firstSetTargets;
    public GameObject[] secondSetTargets;
    public AudioSource finalAudio;

    private int remainingTargets;

    void Start()
    {
        // Start playing the initial audio
        initialAudio.Play();

        // Subscribe to the audio finished event
        StartCoroutine(WaitForAudioToFinish(initialAudio));
    }

    IEnumerator WaitForAudioToFinish(AudioSource audioSource)
    {
        // Wait until the audio has finished playing
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        // Deactivate first set of targets
        foreach (GameObject target in firstSetTargets)
        {
            target.SetActive(false);
        }

        // Activate second set of targets
        foreach (GameObject target in secondSetTargets)
        {
            target.SetActive(true);
        }

        // Initialize the remaining targets counter
        remainingTargets = secondSetTargets.Length;
    }

    public void TargetDestroyed()
    {
        remainingTargets--;

        if (remainingTargets <= 0)
        {
            // Play the final audio
            finalAudio.Play();

            // Load the next scene after the final audio finishes
            StartCoroutine(WaitForFinalAudioToFinish(finalAudio));
        }
    }

    IEnumerator WaitForFinalAudioToFinish(AudioSource audioSource)
    {
        // Wait until the final audio has finished playing
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        // Load the next scene
        SceneManager.LoadScene("Decable2");
    }
}