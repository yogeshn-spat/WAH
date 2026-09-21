using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PositionChange : MonoBehaviour
{
    public GameObject ScaffoldPosCurrent,RestartPosCurrent;
    public GameObject ScaffoldPosNext,RestartPosNext;
    public UnityEvent ScaffoldPosEvent;
   
    public void PosChanger()
    {
        ScaffoldPosCurrent.transform.position = ScaffoldPosNext.transform.position;
        ScaffoldPosCurrent.transform.rotation = ScaffoldPosNext.transform.rotation;
        RestartPosCurrent.transform.position = RestartPosNext.transform.position;
        RestartPosCurrent.transform.rotation = RestartPosNext.transform.rotation;
        ScaffoldPosEvent.Invoke();
    }
}
