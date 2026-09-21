using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerStartController : MonoBehaviour
{
    public UnityEvent TimerStartEvent;
    void Start()
    {
        StartTimerFunc();
    }

    public void StartTimerFunc()
    {
        TimerStartEvent.Invoke();
    }

}
