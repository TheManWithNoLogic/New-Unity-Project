using UnityEngine;

public class Gravity : MonoBehaviour{

    public Rigidbody rb;

    public float gravity = 500f;

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(0, gravity, 0);
    }
}
