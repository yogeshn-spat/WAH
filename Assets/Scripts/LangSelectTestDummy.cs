using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LangSelectTestDummy : MonoBehaviour
{
    public UnityEvent Tamil, English, Hindi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            Hindi.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Tamil.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            English.Invoke();
        }
    }
}
