using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recap : MonoBehaviour
{
    public AudioSource audioSource;  // Reference to the AudioSource component
    public string nextSceneName;     // The name of the next scene to load

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource != null)
        {
            // Play the audio and invoke the method to change the scene after the clip duration
            audioSource.Play();
            Invoke("LoadNextScene", audioSource.clip.length);
        }
        else
        {
            Debug.LogError("AudioSource component missing on this GameObject.");
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}