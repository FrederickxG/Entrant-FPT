using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public GameObject pauseMenu;

    public static bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
    Cursor.lockState = CursorLockMode.None;   // Unlock the cursor
     }

    public void ResumeGame()
     {
    pauseMenu.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;
    Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor
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
