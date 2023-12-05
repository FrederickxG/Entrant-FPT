using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParent : MonoBehaviour
{
    // this was made in attempt to stop the error
    public GameObject gunPrefab;
    private GameObject gunInstance;

    private void Awake()
    {
        // Find all existing instances of the gun
        GameObject[] gunInstances = FindObjectsOfType<GameObject>(true);

        // If a gun instance exists, use it
        if (gunInstances.Length > 0)
        {
            foreach (GameObject instance in gunInstances)
            {
                if (instance.name == gunPrefab.name)
                {
                    gunInstance = instance;
                    break;
                }
            }
        }
        // If no gun instance exists, create a new one
        else
        {
            gunInstance = Instantiate(gunPrefab, transform);
            DontDestroyOnLoad(gunInstance);
        }
    }
}