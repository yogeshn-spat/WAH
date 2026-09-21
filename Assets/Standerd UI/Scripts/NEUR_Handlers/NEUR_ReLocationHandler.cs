using UnityEngine.Events;
using Oculus.Interaction;
using UnityEngine;
using System;

public class NEUR_ReLocationHandler : MonoBehaviour
{
    private InteractableUnityEventWrapper InteractableEvent;
    [SerializeField] private Transform environment; // Ensure this is assigned via inspector or initialized properly
    public bool isGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        InteractableEvent = GetComponent<InteractableUnityEventWrapper>();
        // Use AddListener instead of direct assignment
        InteractableEvent.WhenSelect.AddListener(OnSelect);
        InteractableEvent.WhenUnselect.AddListener(OnUnSelect);
    }

    private void Update()
    {
        if (!isGrabbed) return;
        if(isGrabbed)
        {
            // Adjust the environment's position based on object's current position
            Vector3 newPos = transform.position;
            newPos.y = environment.position.y; // Retain the original Y position of the environment
            environment.position = newPos;

            Quaternion newRot = transform.rotation;
            newRot.z = environment.rotation.z;
            newRot.x = environment.rotation.x;
            environment.rotation = newRot;
        }

      
    }

    // Called when the object is grabbed
    public void OnSelect()
    {
        isGrabbed = true;
    }

    // Called when the object is released
    public void OnUnSelect()
    {
        isGrabbed = false;
    }

    private void OnDestroy()
    {
        // Unsubscribe from events to prevent memory leaks
        if (InteractableEvent != null)
        {
            InteractableEvent.WhenSelect.RemoveListener(OnSelect);
            InteractableEvent.WhenUnselect.RemoveListener(OnUnSelect);
        }
    }
}
