using System;
using System.Security.Claims;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dispatch;
public class IDamage : MonoBehaviour
{
    public int Max_HP = 100;
    public int CurrentHP{ get; private set;}

    private void ApplyDamage(int damage)
    {
        Mathf.Clamp(CurrentHP - damage, 0, Max_HP);

        if(CurrentHP == 0){
            Die();
        }
    }

    public virtual void Die(){

    }

    public virtual void OnDestroy(){

    }
}
