using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject gameObjectToNotDestroy;

    public static bool isPaused;
    private bool isFirstTime = true;

    // Start is called before the first frame update
    void Start()
    {
       pauseMenu.SetActive(false);
        DontDestroyOnLoad(gameObjectToNotDestroy); // Add this line to prevent the specified game object from being destroyed on scene load
    }

    // Update is called once per frame
    void Update()
    {
        if(isFirstTime)
        {
            ResumeGame();
            isFirstTime = false;
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

   public void PauseGame()
     {
    pauseMenu.SetActive(true);
    Time.timeScale = 0f;
    isPaused = true;

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
     }

    public void ResumeGame()
     {
    pauseMenu.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
     }
     public void GoToMainMenu()
     {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
     }

     public void Restart()
     {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Manor");
      
     }
}