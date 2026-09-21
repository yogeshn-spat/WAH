using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LookAt : MonoBehaviour
{
    public GameObject Centereye;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Centereye != null)
        {
            // Get the direction from the current position to the target
            Vector3 lookDirection = Centereye.transform.position - transform.position;

            // Calculate the rotation needed to look along the -Z-axis
            Quaternion lookRotation = Quaternion.LookRotation(-lookDirection, Vector3.up);

            // Apply the rotation to the object
            transform.rotation = lookRotation;
        }

    }
}
