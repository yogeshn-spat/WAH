using UnityEngine;

public class CheckObjectPositionOld : MonoBehaviour
{
    public GameObject objectToTurnOff; // The public game object to turn off
    public Transform attachedObject;   // The attached object whose position you want to check

    public GameObject Ray;

    private Vector3 lastPosition;

    void Start()
    {
        // Store the initial position of the attached object
        if (attachedObject != null)
        {
            lastPosition = attachedObject.position;
        }
    }

    void Update()
    {
        // Check if the attached object's position has changed since the last frame
        if (attachedObject != null && attachedObject.position != lastPosition)
        {
            // If the position has changed, turn on the public game object
            //objectToTurnOff.SetActive(true);
            //Ray.SetActive(true);
        }
        else
        {
            // If the position is the same, turn off the public game object
            //objectToTurnOff.SetActive(false);
            //Ray.SetActive(false);
        }

        // Update the last position to the current position
        lastPosition = attachedObject.position;
    }
}