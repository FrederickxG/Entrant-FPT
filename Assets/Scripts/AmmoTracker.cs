using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoTracker : MonoBehaviour
{
    public GameObject gun;
    public TextMeshProUGUI ammoText;
    public GunData gunData;

    private void Start()
    {
        if (gunData == null)
        {
            Debug.LogError("GunData is null! Please assign it in the inspector.");
            return;
        }

        ReloadGunData(); // Load initial ammo data from GunData
    }

    public void ReloadGunData()
    {
        // Update ammo values from the GunData scriptable object
        UpdateAmmoText();
    }

    private void Update()
    {
        // Update the ammo text every frame
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        if (gunData != null)
        {
            ammoText.text = $"{gunData.currentAmmo}/{gunData.magSize}";
        }
    }
}
