using UnityEngine;

public class CraneRotation : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // Axis of rotation
    public float startRotation = 0f; // Starting rotation angle in degrees
    public float endRotation = 180f; // Ending rotation angle in degrees
    public float rotationSpeed = 5f; // Rotation speed in degrees per second

    public float minRandomDelay = 5f; // Minimum random delay in seconds
    public float maxRandomDelay = 60f; // Maximum random delay in seconds

    private bool isRotating = true;

    private void Start()
    {
        // Start rotating the crane
        InvokeRepeating("RotateCrane", 2f, 0.01f); // You can adjust the delay if needed
    }

    private void RotateCrane()
    {
        if (isRotating)
        {
            // Rotate the crane smoothly around the specified axis
            float currentRotation = Time.time * rotationSpeed;
            Quaternion targetRotation = Quaternion.Euler(rotationAxis * currentRotation);
            transform.rotation = targetRotation;

            // Check if end rotation is reached
            if (currentRotation >= endRotation)
            {
                isRotating = false;

                // Invoke a random delay before restarting the rotation
                float randomDelay = UnityEngine.Random.Range(minRandomDelay, maxRandomDelay);
                Invoke("RestartRotation", randomDelay);
            }
        }
    }

    private void RestartRotation()
    {
        // Reset rotation state and start rotating again from the start rotation
        isRotating = true;
    }
}
