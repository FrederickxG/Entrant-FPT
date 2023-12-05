using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Gun gun;
    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadkey = KeyCode.R;

    private void Update()
    {

      // takes input for wether player is press on mouse button or reload key to invoke the inputs
        if (Input.GetMouseButtonDown(0))
        {
            shootInput?.Invoke();
            
        }

        if (Input.GetKeyDown(reloadkey))
        {
            reloadInput?.Invoke();
            
        }
    }
}