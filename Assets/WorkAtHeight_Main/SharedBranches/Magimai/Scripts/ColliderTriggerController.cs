using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderTriggerController : MonoBehaviour
{
    public string collidername;
    public UnityEvent Event1;
    public bool SelfDestruct;
    public bool DestorySource = false;
   // public HintController hintController;


    private void Start()
    {
       // hintController = FindObjectOfType<HintController>();
    }
    void OnTriggerEnter(Collider other)
    {
      //  Debug.Log("Printed");
        if(other.transform.name == collidername)
        {

           
            if(DestorySource == true)
            {
               Destroy(other.transform.gameObject);
            } 
            Event1.Invoke();
            if (SelfDestruct)
            {
                transform.gameObject.SetActive(false);
            }
            //if (hintController == null)
            //{ DestorySource = false; }
            //else { hintController.DesableHitButton(); }
            
        }
    }
}
