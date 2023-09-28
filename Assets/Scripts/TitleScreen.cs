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
}
