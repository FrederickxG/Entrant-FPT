using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public GunData gunData;
    [SerializeField] private Transform muzzle;
    [SerializeField] private GameObject muzzleFlash; // Reference to the muzzle flash GameObject


    float timeSinceLastShot;

    private void OnEnable()
    {
        if (gunData == null)
        {
            Debug.LogError($"{gameObject.name} gunData is null!");
            return;
        }

        // shoot and reload input 
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;

        // sets initial ammo
        gunData.currentAmmo = gunData.magSize;

        Debug.Log($"{gameObject.name} enabled with {gunData.currentAmmo} ammo.");
    }

    private void OnDisable()
    {
        PlayerShoot.shootInput -= Shoot;
        PlayerShoot.reloadInput -= StartReload;
        gunData.reloading = false;

        Debug.Log($"{gameObject.name} disabled.");
    }

    public void StartReload()
    {
        if (!gunData.reloading && gunData.currentAmmo < gunData.magSize)
        {
            Debug.Log($"{gameObject.name} started reloading.");
            StartCoroutine(Reload()); // starts reload time
        }
    }

    private IEnumerator Reload() // reload method
    {
        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;
        gunData.reloading = false;

        Debug.Log($"{gameObject.name} reloaded.");
    }

    private bool CanShoot()
    {
        bool canShoot = !gunData.reloading && timeSinceLastShot >= 1f / gunData.fireRate;
        Debug.Log($"{gameObject.name} CanShoot: {canShoot}, reloading: {gunData.reloading}, timeSinceLastShot: {timeSinceLastShot}");
        return canShoot;
    }

    private void Shoot()
    {
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                Debug.Log($"{gameObject.name} is shooting.");

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
                    timeSinceLastShot = 0; // Reset the timer after shooting

                    Debug.Log($"{gameObject.name} shot! Remaining ammo: {gunData.currentAmmo}");
                }
                else
                {
                    Debug.Log($"{gameObject.name} shot but didn't hit anything.");
                }
            }
            else
            {
                Debug.Log($"{gameObject.name} tried to shoot but can't right now.");
            }
        }
        else
        {
            Debug.Log($"{gameObject.name} has no ammo left.");
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
