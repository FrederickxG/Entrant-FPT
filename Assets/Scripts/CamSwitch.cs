using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
  public GameObject cam1;

  public GameObject cam2;

  public GameObject cam3;


    void Update()
    {
         if (Input.GetButtonDown("Switch1"))
         {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
         }else if (Input.GetButtonDown("Switch2"))
         {
            
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
         }
         else if (Input.GetKeyDown(KeyCode.Alpha3))
         {
            Debug.Log ("Switch 3");
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
         }
    }
}