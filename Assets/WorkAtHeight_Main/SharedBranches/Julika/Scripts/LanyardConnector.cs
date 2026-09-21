using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LanyardConnector : MonoBehaviour
{
    public GameObject LeftHook;
    public GameObject RightHook;
    public GameObject LeftHookPos;
    public GameObject RightHookPos;

    public UnityEvent ColliderEvent;
    // Start is called before the first frame update
    void Start()
    {
        HookConnector();
        ColliderEvent.Invoke();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HookConnector()
    {
        LeftHook.transform.position = LeftHookPos.transform.position;   
        LeftHook.transform.rotation = LeftHookPos.transform.rotation;
        RightHook.transform.position = RightHookPos.transform.position;
        RightHook.transform.rotation = RightHookPos.transform.rotation;
    }



}
