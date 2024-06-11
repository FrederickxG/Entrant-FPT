using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rescue : MonoBehaviour
{
    public AudioClip voiceLine; 
    private bool voiceLinePlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        // Play the voice line when the scene starts
        StartCoroutine(PlayVoiceLine());
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the voice line has finished playing and send to the next scene
        if (voiceLinePlayed) 
        {
            SceneManager.LoadScene("Recap"); // Load the "recap" scene
        }
    }

    IEnumerator PlayVoiceLine()
    {
        AudioSource audioSource = GetComponent<AudioSource>(); 
        if (voiceLine != null && audioSource != null)
        {
            audioSource.clip = voiceLine;
            audioSource.Play();
            yield return new WaitForSeconds(voiceLine.length);
            voiceLinePlayed = true;
        }
        else
        {
            Debug.LogError("Voice line audio clip or AudioSource is missing!");
        }
    }
}
