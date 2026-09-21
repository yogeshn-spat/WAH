using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarnessController : MonoBehaviour
{
    public GameObject chestjoint;
    public GameObject LOD,LOD1,LOD2,LOD3,LOD4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chestjoint = GameObject.Find("Joint Chest");
        LOD = GameObject.Find("LOD0");
        LOD1 = GameObject.Find("LOD1");
        LOD2 = GameObject.Find("LOD2");
        LOD3 = GameObject.Find("LOD3");
        LOD4 = GameObject.Find("LOD4");
        if (chestjoint != null ) 
        {
            transform.position = chestjoint.transform.position;
            transform.rotation = chestjoint.transform.rotation;
            if (LOD!=null)
            {
                LOD.SetActive(false);

            }
            if (LOD1 != null)
            {
                LOD1.SetActive(false);

            }
            if (LOD2 != null)
            {
                LOD2.SetActive(false);


            }
            if (LOD3 != null)
            {
                LOD3.SetActive(false);

            }
            if (LOD4 != null)
            {
                LOD4.SetActive(false);

            }

            //transform.parent = chestjoint.transform;
        }
       
    }
}
