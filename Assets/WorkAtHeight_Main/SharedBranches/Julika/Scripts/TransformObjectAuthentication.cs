using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformObjectAuthentication : MonoBehaviour
{
    public Transform targetTransform; // The target position to move the object to (X and Z axes)
    public Transform lookAtTarget; // The target object to make the object face
    public float moveSpeed = 5f; // Speed at which the object moves
    public Space transformationSpace = Space.World; // Use global or local space

    public bool lookAtXAxis = true; // Should the object look at the X-axis?
    public bool lookAtYAxis = true; // Should the object look at the Y-axis?
    public bool lookAtZAxis = true; // Should the object look at the Z-axis?

    private bool isMoving = false; // Flag to track if the object is currently moving

    private Vector3 initialPosition; // Initial position of the object

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Calculate the step size
            float step = moveSpeed * Time.deltaTime;

            // Calculate the target position in the specified space (global or local)
            Vector3 targetPosition = transformationSpace == Space.World ? targetTransform.position : targetTransform.localPosition;
            targetPosition.y = initialPosition.y; // Maintain the same Y-axis position

            // Move the object towards the target position along the X and Z axes
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Check if the object has reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Deactivate the movement
                isMoving = false;

                // Calculate the lookAtDirection based on the boolean variables
                Vector3 lookAtDirection = Vector3.zero;
                if (lookAtXAxis) lookAtDirection += Vector3.right;
                if (lookAtYAxis) lookAtDirection += Vector3.up;
                if (lookAtZAxis) lookAtDirection += Vector3.forward;

                // Make the object face the lookAtTarget when movement stops
                if (lookAtTarget != null && lookAtDirection != Vector3.zero)
                {
                    transform.LookAt(lookAtTarget, lookAtDirection);
                }
            }
        }
    }

    public void ToggleTransformation()
    {
        if (!isMoving)
        {
            isMoving = true;
        }
    }
}
