using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followtargett : MonoBehaviour
{
    //public Transform targett;
    public GameObject parentobj;
    public GameObject newparent;

    public void Reach()
    {
        parentobj.transform.parent = newparent.transform;
        //gameObject.transform.position = targett.position;
        //gameObject.transform.rotation = targett.rotation;
    }

}
