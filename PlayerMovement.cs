using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public Rigidbody rb;

    public float SidewaysForce = 500f;
    public float ForwardForce = 500f;

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, ForwardForce * Time.deltaTime, ForceMode.VelocityChange); //Enables forward movement on keypress
            
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); //Enables left movement on keypress
            
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -ForwardForce * Time.deltaTime, ForceMode.VelocityChange); //Enables back movement on keypress
            
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); //Enables right movement on keypress
            
        }

    }   
}
