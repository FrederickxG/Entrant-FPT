using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTest : MonoBehaviour, IInteractable
{
   public GameObject collect;
     public GameObject Boss;
    // used to test interaction
   public void Interact() 
   {
    Debug.Log("working");
     if (gameObject == collect)
        {
            // Collect 
            collect.SetActive(false);

            Boss.SetActive(true);
        }
    Debug.Log("Test");
   }
}