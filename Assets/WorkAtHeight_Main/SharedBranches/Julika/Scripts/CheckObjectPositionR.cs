using System.Runtime.InteropServices;
using UnityEngine;

public class CheckObjectPositionR : MonoBehaviour
{
    public GameObject objectToTurnOff; // The public game object to turn off
    public Transform attachedObject;   // The attached object whose position you want to check

    public LineRenderer Ray;
    public RaycastVisualization raycastVisualization;
    private Vector3 lastPosition;
    public int lengthh = 10;
    public float t = 0;
    public float speed;


    void Start()
    {
        raycastVisualization.raycastLength = 0;
        // Store the initial position of the attached object
        if (attachedObject != null)
        {
            lastPosition = attachedObject.position;
        }
    }

    void Update()

    {
        if (Ray.enabled == false)
        {
            raycastVisualization.raycastLength = 0;
            t = 0;
        }
        // Check if the attached object's position has changed since the last frame
        if (attachedObject != null && attachedObject.position != lastPosition)
        {
            // If the position has changed, turn on the public game object
            objectToTurnOff.SetActive(true);
            Ray.enabled = true;
           
            if(raycastVisualization.raycastLength <= lengthh)
            {
                raycastVisualization.raycastLength = t + Time.deltaTime*speed;
                t = raycastVisualization.raycastLength;
            }
        }
        else
        {
            // If the position is the same, turn off the public game object
            objectToTurnOff.SetActive(false);
            Ray.enabled = false;
            raycastVisualization.raycastLength = 0;
            t = 0;
        }

        // Update the last position to the current position
        lastPosition = attachedObject.position;
        
    }

 
}