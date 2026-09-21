using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
   // Variables for primary arrow behavior
    [Header("Primary Target Settings")]
    // The primary target that the arrow should point towards
    public Transform target;
    public float primaryMinScale = 0.05f;
    public float primaryMaxScale = 0.2f;
    public float primaryVisibilityScaleFactor = 0.8f;
    public float primaryViewOffset = 0.3f;
    public float primaryDistance = 1.0f;
    [Range(0f, 0.5f)] public float primaryViewMargin = 0.1f;

    // Variables for UI target behavior
    [Header("UI Target Settings")]
    // Tag of the secondary target objects that will hide the arrow if any are in view
    public string UITargetTag;
    private List<Transform> UITargets = new List<Transform>();
    public float UIMinScale = 0.05f;
    public float UIMaxScale = 0.2f;
    public float UIVisibilityScaleFactor = 0.8f;
    public float UIViewOffset = 0.3f;
    public float UIDistance = 1.0f;
    [Range(0f, 0.5f)] public float UIViewMargin = 0.1f;

    private Camera mainCamera;
    private bool arrowVisible = false;

    void Start()
    {
        mainCamera = Camera.main;
        GetUITarget();
        UpdateArrowVisibility(ShouldShowArrow());
    }

    public void GetUITarget()
    {
        GameObject[] UITargetObjects = GameObject.FindGameObjectsWithTag(UITargetTag);
        foreach (GameObject obj in UITargetObjects)
        {
            UITargets.Add(obj.transform);
        }
    }

    void Update()
    {
        bool showArrow = ShouldShowArrow();
        if (showArrow != arrowVisible)
        {
            UpdateArrowVisibility(showArrow);
        }

        if (arrowVisible)
        {
            UpdateArrowPositionAndRotation();
        }
    }

    private bool ShouldShowArrow()
    {
        // If the primary target is null, return false (don't show the arrow)
        if (target == null)
        {
            return false;
        }

        // Check if any UI target is in view; if so, hide the arrow
        foreach (Transform secondaryTarget in UITargets)
        {
            if (IsTargetInView(secondaryTarget, UIViewMargin))
            {
                return false; // Hide the arrow if any UI target is visible
            }
        }

        // Check if the primary target is within the camera's field of view
        return !IsTargetInView(target, primaryViewMargin);
    }

    private bool IsTargetInView(Transform target, float viewMargin)
    {
        // Check if the target is within the camera's field of view
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(target.position);

        // Apply the view margin to control when the arrow turns off
        return viewportPoint.z > 0 &&
               viewportPoint.x > viewMargin && viewportPoint.x < 1 - viewMargin &&
               viewportPoint.y > viewMargin && viewportPoint.y < 1 - viewMargin;
    }

    private void UpdateArrowVisibility(bool showArrow)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = showArrow;
        }

        arrowVisible = showArrow;
    }

    private void UpdateArrowPositionAndRotation()
    {
        // Calculate the direction from the camera to the primary target
        Vector3 cameraToTarget = (target.position - mainCamera.transform.position).normalized;

        // Project the direction onto the screen plane
        Vector3 screenDirection = Vector3.ProjectOnPlane(cameraToTarget, mainCamera.transform.forward).normalized;

        // If the screen direction is zero, default to the right direction
        if (screenDirection == Vector3.zero)
        {
            screenDirection = mainCamera.transform.right;
        }

        // Set the arrow's position offset from the camera
        Vector3 arrowPosition = mainCamera.transform.position + mainCamera.transform.forward * primaryDistance + screenDirection * primaryViewOffset;
        transform.position = arrowPosition;

        // Rotate the arrow to point towards the target
        transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward, screenDirection);

        // Scale the arrow based on the target's distance from the camera
        float distanceToTarget = Vector3.Distance(mainCamera.transform.position, target.position);
        float angleToTarget = Vector3.Angle(cameraToTarget, mainCamera.transform.forward);
        float visibilityScale = mainCamera.fieldOfView * 0.5f * primaryVisibilityScaleFactor;

        float arrowScaleFactor = Mathf.Lerp(primaryMinScale, primaryMaxScale, (angleToTarget - visibilityScale) / (180f - visibilityScale));
        transform.localScale = Vector3.one * arrowScaleFactor;
    }

    // Method to update the primary target viewOffset at runtime
    public void SetPrimaryViewOffset(float newOffset)
    {
        primaryViewOffset = newOffset;
    }

    // Method to update the primary target forwardBackwardOffset at runtime
    public void SetPrimaryForwardBackwardOffset(float newOffset)
    {
        primaryDistance = newOffset;
    }

    // Method to update the UI target viewOffset at runtime
    public void SetUIViewOffset(float newOffset)
    {
        UIViewOffset = newOffset;
    }

    // Method to update the UI target forwardBackwardOffset at runtime
    public void SetUIForwardBackwardOffset(float newOffset)
    {
        UIDistance = newOffset;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
