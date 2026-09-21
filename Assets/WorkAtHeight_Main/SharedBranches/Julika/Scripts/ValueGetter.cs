using JetBrains.Annotations;
using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueGetter : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform OVRCameraRig;
    public Vector3 OVRCameraTarget;

    public Transform NextObj;
    public Transform CenterEyeValue;
    public Transform CenterEyeTarget;
    public void GetValue()
    {
        CenterEyeTarget.position = CenterEyeValue.transform.position;
        //Debug.Log("PosValuee"+CenterEyeValue.transform.position);
        //OVRCameraRig.position = OVRCameraRig.position - CenterEyeTarget;
        OVRCameraRig.position = OVRCameraRig.position - CenterEyeTarget.position;
        OVRCameraRig.position = NextObj.position;

    }
}
