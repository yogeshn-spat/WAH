using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    public OVRVirtualKeyboardSampleControls controls;

    public void DestroyBoard()
    {
        controls.DestroyKeyboard();
    } 
}
