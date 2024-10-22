using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight;  // Assign your directional light here
    public float dayLengthInSeconds = 90f;  // Duration of the full day-night cycle

    private float timePassed = 0f;

    void Update()
    {
        // Calculate the rotation angle per frame based on time
        float rotationSpeed = 360f / dayLengthInSeconds;

        // Update the light's rotation
        directionalLight.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);

        // Track time passed for any additional logic if needed
        timePassed += Time.deltaTime;
    }
}

