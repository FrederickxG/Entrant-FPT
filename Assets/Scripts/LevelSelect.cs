using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
   public void Lvl1()
   {
    SceneManager.LoadScene("Manor");
   }
   
   public void Lvl2()
   {
    SceneManager.LoadScene("Village");
   }

   public void Level3()
   {
    SceneManager.LoadScene("Bunker");
   }

   public void Level4()
   {
    SceneManager.LoadScene("Decable");
   }

   public void Level5()
   {
    SceneManager.LoadScene("Recap");
   }

    public void Level6()
   {
    SceneManager.LoadScene("Failsafe");
   }

    public void Credits()
   {
    SceneManager.LoadScene("Credits");
   }

   public void Back()
   {
    SceneManager.LoadScene("TitleScreen");
   }
}
