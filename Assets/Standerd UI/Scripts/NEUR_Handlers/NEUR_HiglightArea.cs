using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NEUR_HiglightArea : MonoBehaviour
{
  public UnityEvent ApplicationStartEvent;
    private void OnTriggerEnter(Collider other)
    {

        if ( other.gameObject.GetComponent<HeadCollisionDetector>() != null)
        {
            ApplicationStartEvent?.Invoke();
        }
    }
}
