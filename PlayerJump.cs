using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public BottomCollide Bottom;
    Rigidbody rb;
    public float jumpVelocity;
    public float doublejumpVelocity;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public int DoubleJumpCounter = 2;
    public bool HasJumped = false;

    public float FlipTorque = 5f;

    public float DiagonalVelocity;
    public float DirectionalAngle;

    
    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Bottom.Ground_Contact == true)
        {
            //Resets body constraints when on the floor
            rb.constraints = RigidbodyConstraints.None;
        }

        if (Input.GetKeyDown("space") && HasJumped == false && Bottom.Ground_Contact == true)
        {
            rb.velocity += (Vector3.up * -1 * rb.velocity.y) + (Vector3.up * jumpVelocity);
            HasJumped = true;
            Bottom.Ground_Contact = false;
        }


        else if (Input.GetKeyDown("space") && Bottom.Ground_Contact == false && DoubleJumpCounter > 0)
        {

            //Calculating Diagonal Velocity
            Debug.Log("X Axis: " + rb.velocity.x + " Z Axis: " + rb.velocity.z);
            DiagonalVelocity = Mathf.Sqrt((rb.velocity.z * rb.velocity.z) + (rb.velocity.x * rb.velocity.x));


            //Stationary Twirl
            if ((rb.velocity.x * rb.velocity.x) < 1 && (rb.velocity.z * rb.velocity.z) < 1)
            {
                if (Random.Range(-1f, 1f) >= 0)
                {
                    rb.AddTorque(0, FlipTorque * Time.deltaTime, 0);
                }
                else
                {
                    rb.AddTorque(0, -FlipTorque * Time.deltaTime, 0);
                }
                Debug.Log("Twirl");
            }

                        
            //Moving Forward Right
            else if (rb.velocity.z > 1 && rb.velocity.x > 1)
            {
                DirectionalAngle = Mathf.Asin(rb.velocity.x / DiagonalVelocity);
                //Debug.Log("Directional Angle is " + DirectionalAngle);

                // Front Right Flip
                rb.AddTorque(Mathf.Cos(DirectionalAngle) * FlipTorque * Time.deltaTime, 0, -Mathf.Sin(DirectionalAngle) * FlipTorque * Time.deltaTime);
                Debug.Log("Front Right");
            }


            //Moving Back Right
            else if (rb.velocity.z < -1 && rb.velocity.x > 1)
            {
                DirectionalAngle = Mathf.Asin(rb.velocity.x / DiagonalVelocity);
                //Debug.Log("Directional Angle is " + DirectionalAngle);

                // Back Right Flip
                rb.AddTorque(-Mathf.Sin(DirectionalAngle) * FlipTorque * Time.deltaTime, 0, -Mathf.Cos(DirectionalAngle) * FlipTorque * Time.deltaTime);
                Debug.Log("Back Right");
            }


            //Moving Back Left

            else if (rb.velocity.z < -1 && rb.velocity.x < -1)
            {
                DirectionalAngle = Mathf.Asin(-rb.velocity.x / DiagonalVelocity);
                //Debug.Log("Directional Angle is " + DirectionalAngle);

                // Back Left Flip
                rb.AddTorque(-Mathf.Cos(DirectionalAngle) * FlipTorque * Time.deltaTime, 0, Mathf.Sin(DirectionalAngle) * FlipTorque * Time.deltaTime);
                Debug.Log("Back Left");
            }


            //Moving Front Left
            else if (rb.velocity.z > 1 && rb.velocity.x < -1)
            {

                DirectionalAngle = Mathf.Asin(-rb.velocity.x / DiagonalVelocity);
                //Debug.Log("Directional Angle is " + DirectionalAngle);

                // Front Left Flip
                rb.AddTorque(Mathf.Cos(DirectionalAngle) * FlipTorque * Time.deltaTime, 0, Mathf.Sin(DirectionalAngle) * FlipTorque * Time.deltaTime);
                Debug.Log("Front Left");
            }

            //Moving Forward
            else if (rb.velocity.z > 1)
            {
                // Front Flip
                rb.AddTorque(FlipTorque * Time.deltaTime, 0, 0);
                Debug.Log("Front");
            }

            //Moving Right
            else if (rb.velocity.x > 1)
            {
                // Right Flip
                rb.AddTorque(0, 0, -FlipTorque * Time.deltaTime);
                Debug.Log("Right");
            }

            //Moving Left
            else if (rb.velocity.x < -1)
            {
                // Left Flip
                rb.AddTorque(0, 0, FlipTorque * Time.deltaTime);
                Debug.Log("Left");
            }

            //Moving Back
            else if (rb.velocity.z < -1)
            {
                // Back Flip
                rb.AddTorque(-FlipTorque * Time.deltaTime, 0, 0);
                Debug.Log("Back");
            }



            //Kill vertical velocity and jump
            rb.velocity += (Vector3.up * -1 * rb.velocity.y) + (Vector3.up * doublejumpVelocity);


            DoubleJumpCounter += -1;
            //Debug.Log("Number of double jumps lefts " + DoubleJumpCounter);
        }
    
        //Improve jump feel, faster falling
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        else if (rb.velocity.y > 0 && !Input.GetKey("space"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
       
    }
}
