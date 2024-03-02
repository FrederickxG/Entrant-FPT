using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleScreen : MonoBehaviour
{
    
    public string Manor;
   
    public void StartGame()
   {
        SceneManager.LoadScene("Manor");
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

     public void Bugs()
   {
        SceneManager.LoadScene("Bugs");
    }

     public void LvlSelect()
   {
        SceneManager.LoadScene("LvlSelect");
    }

      public void Character()
   {
        SceneManager.LoadScene("Characters");
    }

      public void FreyaCH()
   {
        SceneManager.LoadScene("Freya");
    }

    public void PriestCH()
   {
        SceneManager.LoadScene("Priest");
    }
}