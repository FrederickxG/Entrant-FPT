using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTest : MonoBehaviour, IInteractable
{
    // used to test interaction functions

     public GameObject collect;
     public GameObject Boss;
   public void Interact() 
   {
    Debug.Log("working");
     if (gameObject == collect)
        {
            // Collect 
            collect.SetActive(false);

            Boss.SetActive(true);
        }
   }

}
