using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]

public class Player_Controller : HPComponent
{
    private void Start() {
        GameManager.Instance.Update_HP(CurrentHP);
    }
    void Update()
    {
        if(Input.GetKeyDown("space")) {
           GameManager.Instance.AddScore(2);
        }
    }

}
