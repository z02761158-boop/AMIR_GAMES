
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public float acceleration = 12f;
    public float turnSpeed = 70f;
    public float maxSpeed = 18f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        if (rb.linearVelocity.magnitude < maxSpeed)
            rb.AddForce(transform.forward * move * acceleration,
                ForceMode.Acceleration);

        if (Mathf.Abs(move) > 0.1f)
            transform.Rotate(0f, turn * turnSpeed * Time.fixedDeltaTime, 0f);
    }
}
