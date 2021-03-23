using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMScript_2 : MonoBehaviour
{
    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private Vector2 acceleration;
    private Vector2 velocity;
    private Vector2 rotation; //the current rotation in degrees
    // Start is called before the first frame update
    private Vector2 GetInput() {
        Vector2 input = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y")
        );

        return input;
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //The wanted velocity is the current input scaled by ensitivity
        //This is also the maximum velocity
        Vector2 wantedVelocity = GetInput() * sensitivity;


        //Calculate new rotation
        velocity = new Vector2(
            Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.x * Time.deltaTime),
            Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime)
        );
        rotation += velocity * Time.deltaTime;
        //rotation += wantedVelocity *Time.deltaTime;

        //Convert the rotation to euler angles
        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }
}
