using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIEnableNearby : MonoBehaviour
{
    public Transform CameraPos;
    public Transform UI;
    public float X, Y, Z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIPosition()
    {
        //var yRotation = CameraPos.transform.eulerAngles.y;
        //var xRotation = CameraPos.transform.eulerAngles.x;
        //var zRotation = CameraPos.transform.eulerAngles.z;

        UI.transform.position = new Vector3(CameraPos.position.x +X, CameraPos.position.y +Y, CameraPos.position.z+Z);
        //UI.transform.Rotate(xRotation, yRotation, zRotation);
    }
}


