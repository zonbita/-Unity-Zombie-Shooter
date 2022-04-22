using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapon_Modify : MonoBehaviour
{
    [Header("Game Object")]
    public GameObject bullet, pointShot, muzzleFlash;
    public float shootForce = 300, upwardForce;

    public float timeDelay = 1, reloadTime = 2, TimeShoot = 0.1f;
    public int AmmoSize = 100, ammoTap = 1;
    public bool Hold = true;
    int ammoLeft, ammoShot;
    
    bool isShoot, isReady, isReload, Allow = true;
    
    private void Awake()
    {
        ammoLeft = AmmoSize;
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

        GameObject currentBullet = Instantiate(bullet, pointShot.transform.position, Quaternion.identity);
        currentBullet.transform.forward = pointShot.transform.forward;

        currentBullet.GetComponent<Rigidbody>().AddForce(pointShot.transform.forward.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(pointShot.transform.up * upwardForce, ForceMode.Impulse);
        
        if(muzzleFlash != null)
            Instantiate(muzzleFlash, pointShot.transform.position, Quaternion.identity);

        ammoLeft--;
        ammoShot++;

        if(Allow)
        {
            Invoke("Reset", TimeShoot);
            Allow = false;
        }

        if(ammoShot < ammoTap && ammoLeft > 0)
            Invoke("Shoot", TimeShoot);
    }

    private void Reset()
    {
        isReady = true;
        Allow = true;
    }

    private void Reload(){
        isReload = true;
        Invoke("ReloadFinish", reloadTime);
    }

    private void ReloadFinish(){
        ammoLeft = AmmoSize;
        isReload = false;
    }
}

