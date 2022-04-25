using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HPComponent : MonoBehaviour, IDamageable
{
    public int Max_HP = 100;

    public int CurrentHP{ get; private set;}

    private void Awake() {
        CurrentHP = Max_HP;
    }
    public void ApplyDamage(int damage)
    {
        if (damage != 0 ) return;

        CurrentHP -= damage;
        Hit();

        // Debug log
        Debug.Log(CurrentHP);

        if(CurrentHP == 0){
            Die();
        }
    }
    public virtual void Hit(){
        
    }

    public virtual void Die(){
        Destroy(gameObject);
    }

    public virtual void OnDestroy(){

    }
}
