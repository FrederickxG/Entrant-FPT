using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTracker : MonoBehaviour
{
    public GameObject Gun;
    public Text AmmoText;
    public string gunDataName;
    public GunData gunData;

    private int currentAmmo;
    private int magSize;

    void Start()
    {
        ReloadGunData();
    }
   
    public void ReloadGunData()
    {
         currentAmmo = gunData.currentAmmo;
         magSize = gunData.magSize;
    }

    void Update()
    {
        int totalAmmo = gunData.currentAmmo + magSize * gunData.currentAmmo;
        AmmoText.text = "Ammo: " + gunData.currentAmmo;
    }
}