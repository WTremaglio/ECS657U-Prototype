using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed = 5f;

    private Rigidbody rb; 

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
    }

   
    void OnMove(InputValue value)
    {
       
        moveValue = value.Get<Vector2>();
       

    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        rb.velocity = movement * speed; // Directly set the velocity

        // STOP ROTATION on y axis:
        rb.angularVelocity = Vector3.zero;  // Stop unwanted rotation
    }

}
