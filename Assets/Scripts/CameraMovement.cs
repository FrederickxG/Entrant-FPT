using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public Transform targetPosition; // The end position of the camera movement (the end of the hallway)
    public GameObject officeCam; // The office camera GameObject
    public AudioClip hallwayAudioClip; // Audio clip to play while moving down the hall
    public AudioClip officeVoiceLine; // Voice line audio clip to play in the office
    public float movementSpeed = 5f; // Speed at which the camera moves

    private AudioSource audioSource; // AudioSource component

    void Start()
    {
        // Store the initial position of the camera
        audioSource = GetComponent<AudioSource>();

        if (hallwayAudioClip != null && audioSource != null)
        {
            audioSource.clip = hallwayAudioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Hallway audio clip or AudioSource is missing!");
        }
    }

    void Update()
    {
        // Calculate the distance between the current position and the target position
        float distance = Vector3.Distance(transform.position, targetPosition.position);

        // If the distance is greater than a small threshold, move the camera towards the target
        if (distance > 0.1f)
        {
            // Calculate the new position to move the camera towards the target
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition.position, movementSpeed * Time.deltaTime);

            // Update the camera's position
            transform.position = newPosition;

            // Check if the camera has reached the target position
            if (Vector3.Distance(transform.position, targetPosition.position) <= 0.1f)
            {
                SwitchToOfficeCam();
            }
        }
    }

    void SwitchToOfficeCam()
    {
        Debug.Log("Switching to office camera...");

        // Deactivate the main camera (this script's GameObject) and activate the office camera
        gameObject.SetActive(false);
        officeCam.SetActive(true);

        // Stop the hallway audio if it's still playing
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Play the office voice line
        PlayOfficeVoiceLine();
    }

    void PlayOfficeVoiceLine()
    {
        // Check if a voice line is provided
        if (officeVoiceLine != null)
        {
            AudioSource officeAudioSource = officeCam.GetComponent<AudioSource>(); // Assuming AudioSource is attached to the office camera GameObject
            if (officeAudioSource != null)
            {
                officeAudioSource.clip = officeVoiceLine;
                officeAudioSource.Play();
                // Wait for the voice line to finish playing before loading the next scene
                Invoke("LoadNextScene", officeVoiceLine.length);
            }
            else
            {
                Debug.LogError("AudioSource component on office camera is missing!");
            }
        }
        else
        {
            Debug.LogError("Office voice line audio clip is missing!");
        }
    }

    void LoadNextScene()
    {
        // Load the "Manor" scene
        Debug.Log("Loading Manor scene...");
        SceneManager.LoadScene("Manor");
    }
}
