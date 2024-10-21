using UnityEngine;
using UnityEngine.InputSystem; // Ensure you're using UnityEngine.InputSystem

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue; // Holds movement input
    public float speed = 5f; // Speed multiplier for movement

    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        // Get reference to the Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // This method is called when input is detected
    void OnMove(InputValue value)
    {
        // Get movement input as Vector2 from the Input System
        moveValue = value.Get<Vector2>();
        Debug.Log("Move Input: " + moveValue);

    }

    // FixedUpdate is used for physics updates
    void FixedUpdate()
    {
        // Convert moveValue (Vector2) to 3D movement vector (x, 0, z)
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        Debug.Log("Movement vecor" + movement);
        // Apply force to Rigidbody to move the player
        rb.AddForce(movement * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
