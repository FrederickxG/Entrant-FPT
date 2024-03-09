using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public AudioClip transitionSound;

    void Start()
    {
        AudioSource.PlayClipAtPoint(transitionSound, transform.position); // Play transition sound
        Invoke("LoadNextScene", transitionSound.length); // Load next scene after audio length
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Bunker"); // Load the scene named "Bunker"
    }
}
