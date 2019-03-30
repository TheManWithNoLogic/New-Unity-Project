
using UnityEngine;

public class PlayerColl : MonoBehaviour {

    public PlayerMovement movement;

    void OnCollisionEnter(Collision CollisionInfo)
    {
        if (CollisionInfo.collider.tag == "Wall")
        {
            movement.enabled = false;

        }
    }




}
