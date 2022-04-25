using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float DestroyTime;
    public int Damage = 1;
    Rigidbody rb;
    public float launchVelocity = 100f;
    private void Awake()
    {
        Destroy(gameObject, DestroyTime);
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3  (0, launchVelocity,0));
    }

    private void OnTriggerEnter(Collider other) {

        if(other.CompareTag ("Destroy") || other.CompareTag ("Enemy"))
        {
            HPComponent dmg = other.GetComponent<HPComponent>();

            if(dmg)
                other.GetComponent<HPComponent>().ApplyDamage(Damage);
            Destroy(gameObject);
        }
    }
}
