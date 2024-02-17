using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameObjectToNotDestroy;
    public EventSystem eventSystem; // Reference to the EventSystem

    public static bool isPaused;
    private bool isFirstTime = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObjectToNotDestroy);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Deactivate the pause menu on start
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstTime)
        {
            ResumeGame();
            isFirstTime = false;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
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
        // Activate the pause menu and freeze the game
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None; // Unlock cursor when paused
        Cursor.visible = true;

        // Set the EventSystem's current selected object to the first selectable button in the pause menu
        eventSystem.SetSelectedGameObject(pauseMenu.GetComponentInChildren<UnityEngine.UI.Button>().gameObject);
    }

    public void ResumeGame()
    {
        // Deactivate the pause menu and unfreeze the game
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked; // Lock cursor when game isn't paused
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
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
