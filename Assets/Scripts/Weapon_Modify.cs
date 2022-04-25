using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioClip))]
public class Weapon_Modify : MonoBehaviour
{
    [Header("Game Object")]
    public WeaponStats weaponStats;
    public GameObject pointShot;
    int ammoLeft, ammoShot;

    bool isShoot, isReady, isReload, Allow = true;
    private CharacterController rb;
    AudioSource audio;

    private void Awake()
    {
        rb = GetComponentInParent<CharacterController>();
        audio = GetComponent<AudioSource>();
        ammoLeft = weaponStats.AmmoSize;
        isReady = true;
    }

    private void Update()
    {
        Press();
    }

    void Press(){
        // Check Hold Shoot Button
        if(Allow) isShoot = Input.GetKey(KeyCode.Mouse0);
        else isShoot = Input.GetKeyDown(KeyCode.Mouse0);

        // Reload
        if(Input.GetKeyDown(KeyCode.R) && ammoLeft > 0 && !isReload) Reload();

        if(isReady && isShoot && !isReload && ammoLeft <= 0) Reload();

        if(isReady && isShoot && !isReload && ammoLeft > 0){
            ammoShot = 0;
            Shoot();
        }
    }

    private void Shoot(){
        isReady = false;

        GameObject currentBullet = Instantiate(weaponStats.projectile, pointShot.transform.position + (pointShot.transform.forward * 1.5f), Quaternion.identity);
        currentBullet.transform.forward = pointShot.transform.forward;

        currentBullet.GetComponent<Rigidbody>().AddForce(pointShot.transform.forward * weaponStats.shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(pointShot.transform.up * weaponStats.upwardForce, ForceMode.Impulse);
        //Debug.Log(pointShot.transform.forward);
        if(weaponStats.MuzzleFlash != null)
            Instantiate(weaponStats.MuzzleFlash, pointShot.transform.position, Quaternion.identity);
        if(audio){
            audio.PlayOneShot(weaponStats.ShootSound);
        }
            
        ammoLeft--;
        ammoShot++;

        if(Allow)
        {
            Invoke("Reset", weaponStats.TimeShoot);
            Allow = false;
        }

        if(ammoShot < weaponStats.ClipTab && ammoLeft > 0)
            Invoke("Shoot", weaponStats.TimeShoot);
    }

    private void Reset()
    {
        isReady = true;
        Allow = true;
    }

    private void Reload(){
        isReload = true;
        Invoke("ReloadFinish", weaponStats.reloadTime);
    }

    private void ReloadFinish(){
        ammoLeft = weaponStats.AmmoSize;
        isReload = false;
    }
}

