using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBarFill;
    public AudioClip loadingSoundClip; // Audio clip to play before loading
    public AudioSource audioSource; // Audio source to play the loading sound

    public void LoadScene(int sceneId)
    {
        StartCoroutine(PlayLoadingSoundAndLoadScene(sceneId));
    }

    IEnumerator PlayLoadingSoundAndLoadScene(int sceneId)
    {
        if (loadingSoundClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(loadingSoundClip);
            yield return new WaitForSecondsRealtime(loadingSoundClip.length);
        }

        // Start loading scene asynchronously
        yield return StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        LoadingScreen.SetActive(true); // Activates the loading screen

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f); // Speed at which it loads
            LoadingBarFill.fillAmount = progressValue; // Fills bar as it loads 
            yield return null;
        }
    }
}
