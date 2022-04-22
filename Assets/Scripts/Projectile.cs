using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float DestroyTime;
    private void Awake()
    {
        Invoke("OnDestroy", DestroyTime);
    }

    void OnDestroy()
    {
        Destroy (this.gameObject);
    }
}
