using UnityEngine;

public class PlayerDblJump : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerJump Jump;


    public float JumpForce = 2000f;

    // Update is called once per frame
    void Update()
    {

        if (Jump.enabled == false) //Checks for initial jump being used already
        {
            if (Input.GetKey("space"))
            {
                rb.AddForce(0, JumpForce * Time.deltaTime, 0, ForceMode.VelocityChange); //Enables upwards movement on keypress
            }

        }

       



    }
}
