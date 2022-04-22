using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dispatch;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]

public class Player_Controller : IDamage
{
    protected PlayerInput m_Input;

    private void Awake()
    {
   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")) {
            EventManager.EmitEventData("Add_Score", 5);
        }

        
    }

}
