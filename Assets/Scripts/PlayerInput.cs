using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance
    {
        get { return _Instance; }
    }

    protected static PlayerInput _Instance;

    [SerializeField]
    public float moveSpeed = 60.0F;
    private CharacterController Controller;

    public enum CharacterState {Idle, Walk, Run, Crouch, Roll, Slide}
    public CharacterState characterState;
    
    public enum CombatState {Standby, CombatIdle, Attack, Defend}
    public CombatState combatState;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        StartCoroutine("Movement");
    }

    void Update()
    {
        float speedX = Input.GetAxis("Horizontal") * moveSpeed;
        float speedZ = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 movement = new Vector3(speedX, 0, speedZ);
        Controller.Move(movement * Time.deltaTime);

        if(Controller.velocity.magnitude != 0.0f){
            if(characterState == CharacterState.Idle)
                characterState = CharacterState.Walk;
        }
        else
        {
            if(characterState != CharacterState.Idle)
                characterState = CharacterState.Idle;
        }
    }


    IEnumerator Movement () 
    {
        while(true)
        {
            switch(characterState)
            {
                case CharacterState.Idle:
                    Idle();
                    break;
                case CharacterState.Walk:
                    Walk();
                    break;
                case CharacterState.Run:
                    Run();
                    break;
            }

            yield return null;
        }
    }

    IEnumerator Combat () 
    {
        while(true)
        {
            switch(combatState)
            {
                case CombatState.Standby:
                    break;
                case CombatState.Attack:
                    Attack();
                    break;
            }

            yield return null;
        }
    }

    void Idle ()
    {

    }

    void Walk ()
    {

    }

    void Run ()
    {

    }

    void Attack ()
    {

    }


}
