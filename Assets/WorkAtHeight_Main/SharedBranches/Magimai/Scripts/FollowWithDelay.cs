using UnityEngine;

public class FollowWithDelay : MonoBehaviour
{
    public Transform target;   // The target GameObject to follow
    public float delay = 1f;   // The delay in seconds
    public bool followX = true;    // Whether to follow the target on the X axis
    public bool followY = true;    // Whether to follow the target on the Y axis
    public bool followZ = true;    // Whether to follow the target on the Z axis
    public float desiredDistanceZ = 5f; // The desired distance in the Z-axis

    private Vector3 velocity = Vector3.zero;  // Velocity for SmoothDamp

    private void LateUpdate()
    {
        Vector3 targetPos = target.position;

        if (!followX)
        {
            targetPos.x = transform.position.x;
        }

        if (!followY)
        {
            targetPos.y = transform.position.y;
        }

        if (followZ)
        {
            // Calculate the desired Z position to maintain the desired distance
            float currentDistanceZ = transform.position.z - target.position.z;
            float deltaDistanceZ = desiredDistanceZ - currentDistanceZ;
            targetPos.z += deltaDistanceZ;
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, delay);
    }
}
