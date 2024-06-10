using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform muzzle;
    [SerializeField] private GameObject muzzleFlash; // Reference to the muzzle flash GameObject

    float timeSinceLastShot;

    private void Start()
    {
        if (gunData == null)
        {
            Debug.LogError("gunData is null!");
            return;
        }

        // shoot and reload input 
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;

        // sets initial ammo
        gunData.currentAmmo = gunData.magSize;
    }

    private void OnDisable()
    {
        PlayerShoot.shootInput -= Shoot;
        PlayerShoot.reloadInput -= StartReload;
        gunData.reloading = false;
    }

    public void StartReload()
    {
        if (!gunData.reloading && gunData.currentAmmo < gunData.magSize)
            StartCoroutine(Reload()); // starts reload time
    }

    private IEnumerator Reload() // reload method
    {
        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 6f);

    private void Shoot()
    {
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                AudioSource.PlayClipAtPoint(gunData.shootSound, muzzle.position, 1f); // plays gun audio

                // Activate the muzzle flash GameObject
                if (muzzleFlash != null)
                {
                    muzzleFlash.SetActive(true);
                }

                if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance)) // set raycast for virtual bullet
                {
                    OnGunShot();
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>(); // damage info
                    damageable?.TakeDamage(gunData.damage);

                    gunData.currentAmmo--;
                    timeSinceLastShot = 0;
                }
            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(muzzle.position, muzzle.forward);
    }

    private void OnGunShot()
    {
        // Deactivate the muzzle flash GameObject after a short delay
        StartCoroutine(DeactivateMuzzleFlash());
    }

    private IEnumerator DeactivateMuzzleFlash()
    {
        yield return new WaitForSeconds(0.1f); // Adjust the delay as needed

        // Deactivate the muzzle flash GameObject
        if (muzzleFlash != null)
        {
            muzzleFlash.SetActive(false);
        }
    }
}
