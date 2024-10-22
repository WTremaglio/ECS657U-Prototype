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
        
        
        rb.AddForce(movement * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        //STOP ROTATION on y axis:

        if (rb.angularVelocity != Vector3.zero)
        {
            rb.angularVelocity = Vector3.zero;  // Stop unwanted rotation
        }
    }
}
