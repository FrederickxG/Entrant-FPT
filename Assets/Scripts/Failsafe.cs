using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Failsafe : MonoBehaviour
{
    public GameObject targetObject; // The object to activate
    public AudioSource audioSource;

    void Start()
    {
        // Start the coroutine to handle the timed events
        StartCoroutine(HandleVoiceLine());
    }

    private IEnumerator HandleVoiceLine()
    {
        // Start playing the voice line
        audioSource.Play();

        // Wait for 11 seconds
        yield return new WaitForSeconds(11f);

        // Activate the target object
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }

        // Wait until the voice line finishes
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Load the Credits scene
        SceneManager.LoadScene("Credits");
    }
}
