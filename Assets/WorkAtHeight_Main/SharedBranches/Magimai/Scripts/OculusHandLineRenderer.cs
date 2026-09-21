using System.Collections;
using UnityEngine;

public class OculusHandLineRenderer : MonoBehaviour
{
    public GameObject linePrefab;
    private LineRenderer lineRenderer;
    private Transform leftHand;
    private Transform rightHand;

    private void Start()
    {
       
        leftHand = GameObject.Find("LeftHandAnchor").transform;
        rightHand = GameObject.Find("RightHandAnchor").transform;


        GameObject lineObject = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = lineObject.GetComponent<LineRenderer>();
        lineRenderer.enabled = false; 

    
        lineObject.AddComponent<OculusHandLineRenderer>();
    }

    private void Update()
    {
     
        RaycastFromHand(leftHand);
        RaycastFromHand(rightHand);
    }

    private void RaycastFromHand(Transform hand)
    {
        if (hand != null && linePrefab!= null)
        {
            Vector3 handPosition = hand.position;
            Vector3 handDirection = hand.forward;

            if (Physics.Raycast(handPosition, handDirection, out RaycastHit hit))
            {
             
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, handPosition);
                lineRenderer.SetPosition(1, hit.point);

         
            }
            else
            {
            
                lineRenderer.enabled = false;
            }
        }
    }
}

