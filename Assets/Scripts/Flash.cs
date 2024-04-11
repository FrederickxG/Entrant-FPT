using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public GameObject objectToToggle;

    void Update()
    {
        // Check if the "X" key is pressed
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Check if the object to toggle is not null
            if (objectToToggle != null)
            {
                // Toggle the activation state of the object
                objectToToggle.SetActive(!objectToToggle.activeSelf);
            }
            else
            {
                Debug.LogError("Object to toggle is not assigned!");
            }
        }
    }
}
