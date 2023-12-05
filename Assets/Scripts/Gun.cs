using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform muzzle;

    float timeSinceLastShot;

    private void Start()
    {
        // shoot and reload input 
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;

        //sets initial ammo
        gunData.currentAmmo = 6;
    }

    private void OnDisable() => gunData.reloading = false;

    public void StartReload() {
        if (!gunData.reloading && this.gameObject.activeSelf)
            StartCoroutine(Reload());//starts reload time
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
                AudioSource.PlayClipAtPoint(gunData.shootSound, muzzle.position, 1f); //plays gun audio
                if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance)) // set raycast for virtual bullet
                {
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();// damage info
                    damageable?.TakeDamage(gunData.damage);

                    gunData.currentAmmo--;
                    timeSinceLastShot = 0;
                    OnGunShot();
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
        
    }

}