using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class TitleSong : MonoBehaviour
{
    public AudioClip music;
    public AudioSource audioSource;

    static TitleSong instance;

    void Awake()
    {
        // If an instance already exists, destroy this one
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Make this object and the audio source persistent across scenes
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(audioSource);

        // Set this as the single instance
        instance = this;

          // Register a scene loaded event listener
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

     void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  {
        // Check if the current scene is one where the music should be stopped
        if (scene.name == "Manor" || scene.name == "Village")
      {
            // Stop the audio source
            audioSource.Stop();
        }
    }

    void Start()
   {
        audioSource.clip = music;
        audioSource.Play();
    }
}