
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadkey = KeyCode.R;

    private void Update()
    {
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