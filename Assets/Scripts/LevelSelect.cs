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

   public void Back()
   {
    SceneManager.LoadScene("TitleScreen");
   }
}
