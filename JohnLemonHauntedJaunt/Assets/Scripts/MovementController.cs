using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController controller;
    private float verticalVelocity;
    //private float gravity = 12.0f;
    //private float jumpForce = 3.0f;
    //[SerializeField] RuntimeData _runtimeData;
    [SerializeField] float _mouseSensitivity = 10f;

    [SerializeField] float _moveSpeed = 6f;
    [SerializeField] Camera _cam;
    float _currentTilt = 0f;
    private bool isSwimming = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        if (isSwimming == true)
        {
            Movement();
        }
        
        if (Input.GetKeyDown("escape")) 
        {
            Cursor.lockState = CursorLockMode.None;
        } 
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        

        transform.Rotate(Vector3.up, mouseX * _mouseSensitivity);
        
        _currentTilt -= mouseY;
        _currentTilt = Mathf.Clamp(_currentTilt, -90,90);
        _cam.transform.localEulerAngles = new Vector3(_currentTilt, 0, 0);
    }
    void Movement()
    {   
        if(Input.GetKeyDown(KeyCode.Space)){
            verticalVelocity = 5;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            verticalVelocity = 0;
        }
        // if(controller.isGrounded)
        // {  
        //     verticalVelocity = -gravity * Time.deltaTime;
        //     if(Input.GetKeyDown(KeyCode.Space))
        //     {
        //         verticalVelocity = jumpForce;
        //     }
        // }
        // else
        // {
        //     verticalVelocity -= gravity * Time.deltaTime;
        // }   

        Vector3 sidewaysMovementVector = transform.right * Input.GetAxis("Horizontal");
        Vector3 upDownMovementVector = transform.up * verticalVelocity;
        Vector3 forwardBackwardMovementVector = transform.forward * Input.GetAxis("Vertical");
        Vector3 movementVector = sidewaysMovementVector + upDownMovementVector +forwardBackwardMovementVector;

    
        GetComponent<CharacterController>().Move(movementVector * _moveSpeed * Time.deltaTime); 
        
           
    }
}

