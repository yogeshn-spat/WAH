using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewObjectPosition : MonoBehaviour
{
    public GameObject ColliderObject;
    public UnityEvent ColliderEvent;
    public UnityEvent ColliderChanged;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ColliderObject)
        {
            ColliderEvent.Invoke();
            StartCoroutine(TimeDelayEvent());
        }
    }

    public IEnumerator TimeDelayEvent()
    {
        yield return new WaitForSeconds(4f);
        ColliderChanged.Invoke();
    }
}
