using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public float smoothTime = 0.12f;
    public Vector3 Offset = new Vector3(0,15,-7);
    private Vector3 velocity = Vector3.zero;
    
    private CharacterController Character;
    private void Awake()
    {
        if (Character == null)
            Character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }    

    private void LateUpdate()
    {

        // update position
        Vector3 targetPosition = Character.transform.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
