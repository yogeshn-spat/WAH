using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class LimitPosition : MonoBehaviour
{
    [SerializeField]
    private float limitXMin;
    [SerializeField]
    private float limitXMax;
    [SerializeField]
    private float limitYMin;
    [SerializeField]
    private float limitYMax;
    [SerializeField]
    private float limitZMin;
    [SerializeField]
    private float limitZMax;

    [SerializeField]
    public Position objectPosition; 


    // Update is called once per frame
    void LateUpdate()
    {
       if(objectPosition==Position.LocalPosition)
        {
            Vector3 pos = transform.localPosition;
            pos.x = Mathf.Clamp(pos.x, limitXMin, limitXMax);
            pos.y = Mathf.Clamp(pos.y, limitYMin, limitYMax);
            pos.z = Mathf.Clamp(pos.z, limitZMin, limitZMax);
            transform.localPosition = pos;
        }

        if (objectPosition == Position.GlobalPosition)
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, limitXMin, limitXMax);
            pos.y = Mathf.Clamp(pos.y, limitYMin, limitYMax);
            pos.z = Mathf.Clamp(pos.z, limitZMin, limitZMax);
            transform.position = pos;
        }
            


    }
    public enum Position
    {
        GlobalPosition,
        LocalPosition

    }
}
