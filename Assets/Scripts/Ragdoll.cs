using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;

    void Start()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody>();
    }

    public void DeactiveRagdoll()
    {
        rb.isKinematic = true;
        animator.enabled = true;
    }

    public void ActiveRagdoll()
    {
        rb.isKinematic = false;
        animator.enabled = false;
    }
}
