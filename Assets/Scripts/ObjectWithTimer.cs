using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectWithTimer : MonoBehaviour
{
    public int timeDelay;
    public UnityEvent objectEvent;
    private void OnEnable()
    {
        Invoke("TimerFunction", timeDelay);
    }

    public void TimerFunction()
    {
        objectEvent.Invoke();
    }
}
