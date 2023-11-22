using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollection : MonoBehaviour
{
   public GameObject key;
   public GameObject door;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == key)
        {
            // Collect the key
            key.SetActive(false);

            // Delete the door
            Destroy(door);
        }
    }
}

