using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFollow : MonoBehaviour
{
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = Target.transform.position;
        gameObject.transform.rotation = Target.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Target.transform.position;
        gameObject.transform.rotation = Target.transform.rotation;
    }
    public void ChangeTarget(GameObject GO)
    {
        Target = GO;
    }
}
