using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Investigation : MonoBehaviour
{
  public void Continue()
  {
    SceneManager.LoadScene("Cene");
  }

   public void Quit()
  {
    SceneManager.LoadScene("TitleScreen");
  }
}

