using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoTracker : MonoBehaviour
{
    public GameObject Gun;
    public TextMeshProUGUI AmmoText;
    public string gunDataName;
    public GunData gunData;

    private int currentAmmo;
    private int magSize;

    void Start()
    {
        ReloadGunData(); // takes the reload data from gundata scriptable object
    }
   
    public void ReloadGunData()
    {
        //set mag and current ammmo values to the vales from the gun data scriptable object
         currentAmmo = gunData.currentAmmo;
         magSize = gunData.magSize;
    }

    void Update()
    {
        // relays ammon onto the ammo text
        int totalAmmo = gunData.currentAmmo + magSize * gunData.currentAmmo;
        AmmoText.text = gunData.currentAmmo + "/6" ;
    }
}