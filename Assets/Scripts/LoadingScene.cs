using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
   public GameObject LoadingScreen;
   public Image LoadingBarFill;

   public void LoadScene(int sceneId)
   {
        StartCoroutine(LoadSceneAsync(sceneId));
   }

 IEnumerator LoadSceneAsync(int sceneId)
 {

    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

    LoadingScreen.SetActive(true); //activates the load screen

    float minLoadTime = 60f; // min time for loading screen to be on screen
    float startTime = Time.time;

    while (!operation.isDone)
    {
        float progressValue = Mathf.Clamp01(operation.progress / 0.9f); // speed in which it loads

        LoadingBarFill.fillAmount = progressValue; //fills bar as loads 

        yield return null;
    }

    float timeWaited = Time.time - startTime;
    if (timeWaited < minLoadTime)
    {
        yield return new WaitForSeconds(minLoadTime - timeWaited);
    }
 }
   
}