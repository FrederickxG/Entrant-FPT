using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleScreen : MonoBehaviour
{
    
    public string TestingGrounds;

    public void StartGame()
    {
        SceneManager.LoadScene("TestingGrounds");
    }

    public void Quit()
    {
         Application.Quit();
         Debug.Log("Player has quit");
    }

     public void InfoScreen()
    {
        SceneManager.LoadScene("StoryInfo");
    }

     public void HelpScreen()
    {
        SceneManager.LoadScene("HelpMenu");
    }

     public void Return()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
