using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating2 : MonoBehaviour
{
    public float hoverForce;
    public float maxForce;
    
    
    void FixedUpdate()
    {

    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Collision Detected");
        if(other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
 
            // Limit velocity of object
            if(other.GetComponent<Rigidbody>().velocity.magnitude > maxForce)
            {
                other.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(other.GetComponent<Rigidbody>().velocity, maxForce);
            }
        }
    }
}
