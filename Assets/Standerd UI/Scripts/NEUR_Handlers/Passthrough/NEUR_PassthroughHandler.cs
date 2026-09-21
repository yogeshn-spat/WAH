using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEUR_PassthroughHandler : MonoBehaviour
{
    OVRPassthroughLayer passthroughLayer;
    bool isPassthroughActive = false;
    // Set camera background to transparent
    OVRCameraRig ovrCameraRig;
    Camera centerCamera;
    void Start()
    {
        passthroughLayer = FindObjectOfType<OVRPassthroughLayer>();
        ovrCameraRig = FindObjectOfType<OVRCameraRig>();
        centerCamera = ovrCameraRig.centerEyeAnchor.GetComponent<Camera>();
        DisablePassthrough();
    }

    // This method toggles passthrough on/off
    public void TogglePassthrough()
    {
        isPassthroughActive = !isPassthroughActive;

        if (isPassthroughActive)
        {
            EnablePassthrough();
        }
        else
        {
            DisablePassthrough();
        }
    }
    public void TogglePassthrough(bool value)
    {

        if (value)
        {
            EnablePassthrough();
        }
        else
        {
            DisablePassthrough();
        }
    }

    public void EnablePassthrough()
    {
        passthroughLayer.enabled = true;

        // Set camera background to transparent
        centerCamera.clearFlags = CameraClearFlags.SolidColor;
        centerCamera.backgroundColor = Color.clear;

    }

    public void DisablePassthrough()
    {
        passthroughLayer.enabled = false;

        // Revert camera background and enable any VR background elements
        centerCamera.clearFlags = CameraClearFlags.Skybox; // Revert to skybox or appropriate clear flag
        centerCamera.backgroundColor = Color.black; // Set to any background color you prefer
    }
}
