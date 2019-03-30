using UnityEngine;

public class BottomCollide : MonoBehaviour{


    public PlayerJump Jump;

    public bool Ground_Contact = false;

    void OnCollisionEnter(Collision CollisionInfo)
    {
        if (CollisionInfo.collider.tag == "Ground")
        {
            Ground_Contact = true;
            Jump.DoubleJumpCounter = 2;
            Jump.HasJumped = false;

        }
    }

    void OnCollisionExit(Collision CollisionInfo)
    {
        if (CollisionInfo.collider.tag == "Ground")
        {
            Ground_Contact = false;

        }
    }


}
