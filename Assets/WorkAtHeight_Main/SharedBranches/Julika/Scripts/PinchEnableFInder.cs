using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PinchEnableFInder : MonoBehaviour
{
    public UnityEvent pincheventSelect, pincheventUnSelect;
    public RaycastVisualization Ray;
    [Header("Select")]
    public float RayStartWidthS;
    public float RayEndWidthS;
    [Header("UnSelect")]
    public float RayStartWidthUnS;
    public float RayEndWidtUnS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pinch"))
        {
            //Ray.StartlineWidth = RayStartWidthS;
            //Ray.EndlineWidth = RayEndWidthS;
            pincheventSelect.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pinch"))
        {
            //Ray.StartlineWidth = RayStartWidthUnS;
            //Ray.EndlineWidth = RayEndWidtUnS;
            pincheventUnSelect.Invoke();
        }
    }
}
