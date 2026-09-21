using UnityEngine;

public class RaycastVisualization : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin; // The starting point of the ray
    public float raycastLength; // The length of the ray
    [SerializeField] public float StartlineWidth;
    [SerializeField] public float EndlineWidth; 
    [SerializeField] private LineRenderer lineRenderer; // Manually assign LineRenderer


    public CheckObjectPosition cp;
    //public AudioSource RaySound;
    public bool HandBool = false;

    public PinchEnableFInder pinch;

    private void Start()
    {

        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer is not assigned!");
            return;
        }

        // Set LineRenderer properties
        lineRenderer.startWidth = pinch.RayStartWidthUnS;
        lineRenderer.endWidth = pinch.RayEndWidtUnS;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.enabled = true; // Always enabled

    }

    private void Update()
    {
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer is not assigned!");
            return;
        }

        // Cast the ray
        RaycastHit hit;
        if (lineRenderer.enabled == false)
        {
            raycastLength = 0;
            cp.t = 0;
            //HandBool = true;


        }
        //if (lineRenderer.enabled == true)
        //{
        //    //RaySound.Stop();
        //    if(raycastLength >= 8)
        //    {
        //        if (HandBool)
        //        {
        //            RaySound.Play();
        //            HandBool = false;
        //        }
                
        //    }
        //}
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
            //RaySound.Stop();
        }


    }
}
