using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventAnimation : MonoBehaviour
{
    public UnityEvent Event1;
    public UnityEvent Event2;
    public UnityEvent Event3;
    public UnityEvent Event4;
    public UnityEvent Event5;
    public UnityEvent Event6;
    public UnityEvent Event7;
    public UnityEvent Event8;
    //public UnityEvent Event9;
    //public UnityEvent Event10;


    public void Event111()
    {
        Event1.Invoke();
    }
    public void Event222()
    {
        Event2.Invoke();
    }
    public void Event333()
    {
        Event3.Invoke();
    }

    public void Event444()
    {
        Event4.Invoke();
    }

    public void Event555()
    {
        Event5.Invoke();
    }

    public void Event666()
    {
        Event6.Invoke();
    }
    public void Event777()
    {
        Event7.Invoke();
    }
    public void Event888()
    {
        Event8.Invoke();
    }
    //public void Event999()
    //{
    //    Event9.Invoke();
    //}
    //public void Event100()
    //{
    //    Event10.Invoke();
    //}
}
