using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMScript_1 : MonoBehaviour
{
    public float Speed = 5.0f;
    private float activeForwardSpeed, activeStrafeSpeed, activeSurfaceSpeed;
    public float lookRotateSpeed = 10f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    private bool isBelowSurfaceNormal;
    private bool isSwimming;
    private float surfaceLevel;
    GameObject player;
    

   
    // Start is called before the first frame update
    void Start()
    {

        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        Cursor.lockState = CursorLockMode.Confined;

    }

    // Update is called once per frame
    void Update()
    {   
        //if (player.transform.position.y < surfaceLevel){

            //isSwimming = true;
        
            lookInput.x = Input.mousePosition.x;
            lookInput.y = Input.mousePosition.y;

            mouseDistance.x = (lookInput.x - screenCenter.x); 
            mouseDistance.y = (lookInput.y - screenCenter.y);

            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

            transform.Rotate(-mouseDistance.y * lookRotateSpeed *Time.deltaTime, mouseDistance.x * lookRotateSpeed * Time.deltaTime, 0f, Space.Self);

            activeForwardSpeed = Input.GetAxisRaw("Vertical") * Speed;
            activeStrafeSpeed = Input.GetAxisRaw("Horizontal") * Speed;
            activeSurfaceSpeed = Input.GetAxisRaw("SwimUp") * Speed;

            transform.position += (transform.forward * activeForwardSpeed * Time.deltaTime) + (transform.right * activeStrafeSpeed * Time.deltaTime)+ (transform.up * activeStrafeSpeed * Time.deltaTime);
            transform.position = Vector3.ClampMagnitude(transform.position, 25.0f);
        //}
        // else
        // {
        //     lookInput.x = Input.mousePosition.x;
        //     lookInput.y = Input.mousePosition.y;

        //     mouseDistance.x = (lookInput.x - screenCenter.x); 
        //     mouseDistance.y = (lookInput.y - screenCenter.y);

        //     mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        //     transform.Rotate(-mouseDistance.y * lookRotateSpeed *Time.deltaTime, mouseDistance.x * lookRotateSpeed * Time.deltaTime, 0f, Space.Self);

        //     activeForwardSpeed = Input.GetAxisRaw("Vertical") * Speed;
        //     activeStrafeSpeed = Input.GetAxisRaw("Horizontal") * Speed;
            

        //     transform.position += (transform.forward * activeForwardSpeed * Time.deltaTime) + (transform.right * activeStrafeSpeed * Time.deltaTime);
        //     transform.position = Vector3.ClampMagnitude(transform.position, 25.0f);
        // }
    }
}
