using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class KeyBoardCollider : MonoBehaviour
{
    public UnityEvent trigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "Lefthandkey" || other.gameObject.name == "RightHandkey")
        {
            trigger.Invoke();
        }
    }
}
