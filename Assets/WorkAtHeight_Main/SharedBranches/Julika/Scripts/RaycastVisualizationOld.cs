using System.Diagnostics;
using UnityEngine;

public class RaycastVisualizationOld : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin; // The starting point of the ray
    [SerializeField] private float raycastLength = 10f; // The length of the ray
    [SerializeField] private float lineWidth = 0.02f; // Thickness of the ray
    [SerializeField] private LineRenderer lineRenderer; // Manually assign LineRenderer

    private void Start()
    {
        if (lineRenderer == null)
        {
            return;
        }

        // Set LineRenderer properties
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.enabled = true; // Always enabled
    }

    private void Update()
    {
        if (lineRenderer == null)
        {
            return;
        }

        // Cast the ray
        RaycastHit hit;
        Vector3 rayDirection = transform.forward;

        if (Physics.Raycast(raycastOrigin.position, rayDirection, out hit, raycastLength))
        {
            // The ray hit something, so update LineRenderer positions up to the hit point
            lineRenderer.SetPosition(0, raycastOrigin.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            // The ray didn't hit anything, so update LineRenderer to reach the maximum length
            Vector3 rayEndPoint = raycastOrigin.position + rayDirection * raycastLength;

            lineRenderer.SetPosition(0, raycastOrigin.position);
            lineRenderer.SetPosition(1, rayEndPoint);
        }
    }
}
