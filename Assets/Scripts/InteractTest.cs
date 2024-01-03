using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTest : MonoBehaviour, IInteractable
{
   public GameObject collect;
     public GameObject Boss;
   
   public void Interact() 
   {
     if (gameObject == collect)
        {
            // Collect 
            collect.SetActive(false);

            Boss.SetActive(true);
        }
   }
}