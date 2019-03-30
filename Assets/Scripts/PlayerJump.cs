using UnityEngine;

public class PlayerJump : MonoBehaviour{

    public BottomCollide Bottom;
    Rigidbody rb;
    public float jumpVelocity;
    public float doublejumpVelocity;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public int DoubleJumpCounter = 2;
    public bool HasJumped = false;

    public float FlipTorque = 5f;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && HasJumped == false && Bottom.Ground_Contact == true)
        {
            rb.velocity += (Vector3.up * -1 * rb.velocity.y) + (Vector3.up * jumpVelocity);
            HasJumped = true;
            Bottom.Ground_Contact = false;
        }

        else if (Input.GetKeyDown("space") && Bottom.Ground_Contact == false && DoubleJumpCounter > 0)
        {
            if (rb.velocity.z > 0.1)
            {
                rb.AddTorque(FlipTorque, 0, 0);
            }
            if (rb.velocity.z < -0.1)
            {
                rb.AddTorque(-FlipTorque, 0, 0);
            }
            if (rb.velocity.x > 0.1)
            {
                rb.AddTorque(0, 0, -FlipTorque);
            }
            if (rb.velocity.x < -0.1)
            {
                rb.AddTorque(0, 0, FlipTorque);
            }

            rb.velocity += (Vector3.up * -1 * rb.velocity.y) + (Vector3.up * doublejumpVelocity);
            Debug.Log("Z axis velocity " + rb.velocity.z);

            

            DoubleJumpCounter += -1;
            Debug.Log("Number of double jumps lefts " + DoubleJumpCounter);
        } 
    
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
