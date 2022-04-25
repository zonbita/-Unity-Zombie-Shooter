using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField]
    public Camera mainCamera;
    float ray;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Update()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        
        if(groundPlane.Raycast(cameraRay, out ray))
        {
            Vector3 target = cameraRay.GetPoint(ray);
            Vector3 targetPostition = new Vector3( target.x, this.transform.position.y, target.z ) ;
            this.transform.LookAt( targetPostition ) ;

            //Quaternion.LookRotation(pointToLook);
        }
    }

 
}
