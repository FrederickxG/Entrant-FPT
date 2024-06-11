using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recap : MonoBehaviour
{
    public AudioSource recapAudioSource; // Reference to the recap AudioSource component
    public AudioSource nextAudioSource;  // Reference to the next AudioSource component for the second voice line
    public GameObject cam2;              // The second camera GameObject
    public GameObject door;              // The door GameObject to be set inactive
    public GameObject openDoor;          // The open door GameObject to be set active
    public GameObject nsc;               // The NSC GameObject to be set active
    public string nextSceneName;         // The name of the next scene to load

    private void Start()
    {
        if (recapAudioSource == null)
        {
            recapAudioSource = GetComponent<AudioSource>();
        }

        if (recapAudioSource != null)
        {
            // Play the recap audio and invoke the method to switch camera and activate objects after the clip duration
            recapAudioSource.Play();
            Invoke("SwitchCameraAndActivateObjects", recapAudioSource.clip.length);
        }
        else
        {
            Debug.LogError("Recap AudioSource component missing on this GameObject.");
        }
    }

    private void SwitchCameraAndActivateObjects()
    {
        if (cam2 != null)
        {
            Camera.main.gameObject.SetActive(false); // Deactivate the main camera
            cam2.SetActive(true); // Activate the second camera
        }
        else
        {
            Debug.LogError("Cam2 GameObject is not assigned.");
        }

        if (door != null)
        {
            door.SetActive(false); // Set the door to inactive
        }
        else
        {
            Debug.LogError("Door GameObject is not assigned.");
        }

        if (openDoor != null)
        {
            openDoor.SetActive(true); // Set the open door to active
        }
        else
        {
            Debug.LogError("OpenDoor GameObject is not assigned.");
        }

        if (nsc != null)
        {
            nsc.SetActive(true); // Set the NSC GameObject to active
        }
        else
        {
            Debug.LogError("NSC GameObject is not assigned.");
        }

        if (nextAudioSource != null)
        {
            // Play the next voice line and invoke the method to load the next scene after the clip duration
            nextAudioSource.Play();
            Invoke("LoadNextScene", nextAudioSource.clip.length);
        }
        else
        {
            Debug.LogError("Next AudioSource component is missing or not assigned.");
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Failsafe");
    }
}
