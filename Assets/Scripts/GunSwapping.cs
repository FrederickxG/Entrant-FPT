using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwapping : MonoBehaviour
{
    // References to the shotgun, revolver, and their respective ammo
    public GameObject shotgun;
    public GameObject ammorem; // Ammo for the shotgun
    public GameObject revolver;
    public GameObject ammorev; // Ammo for the revolver

    public AmmoTracker ammoTracker; // Reference to the AmmoTracker script

    void Start()
    {
        // Ensure AmmoTracker is assigned
        if (ammoTracker == null)
        {
            Debug.LogError("AmmoTracker is not assigned in GunSwapping script!");
            return;
        }

        // Set the initial active gun and update AmmoTracker
        SetActiveGun(true);
    }

    void Update()
    {
        // Check for input
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Set shotgun and its ammo active, revolver and its ammo inactive
            SetActiveGun(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Set revolver and its ammo active, shotgun and its ammo inactive
            SetActiveGun(false);
        }
    }

    // Method to set active gun and ammo
    private void SetActiveGun(bool isShotgunActive)
    {
        shotgun.SetActive(isShotgunActive);
        ammorem.SetActive(isShotgunActive);
        revolver.SetActive(!isShotgunActive);
        ammorev.SetActive(!isShotgunActive);

        // Update the AmmoTracker with the active gun's GunData
        Gun activeGun = isShotgunActive ? shotgun.GetComponent<Gun>() : revolver.GetComponent<Gun>();
        if (activeGun != null)
        {
            ammoTracker.gunData = activeGun.gunData;
            ammoTracker.ReloadGunData();
        }
    }
}
