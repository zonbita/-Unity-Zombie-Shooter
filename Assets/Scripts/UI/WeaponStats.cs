using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponStats : ScriptableObject
{
    public string Name;
    public int Damage=1;
    public float Firerate=.1f;
    public int AmmoSize=10;
    public int ClipTab=1;
    public GameObject projectile;
    public GameObject MuzzleFlash;
    public GameObject WeaponPrefab;
    public Sprite WeaponImage;
    public AudioClip ShootSound;
    public AudioClip PickSound;
    public float shootForce = 300;
    public float upwardForce;
    public float timeDelay = 1;
    public float reloadTime = 2;
    public float TimeShoot = 0.1f;
    public bool Hold = true;
}
