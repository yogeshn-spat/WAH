using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPlacement : MonoBehaviour
{
    public GameObject ColliderObject;
    public UnityEvent ColliderEvent;
    public UnityEvent ColliderEvent2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ColliderObject)
        {
            ColliderEvent.Invoke();
            ColliderObject.transform.position = transform.position;
            ColliderObject.transform.rotation = transform.rotation;
            StartCoroutine(Timedela());

        }
    }
    public IEnumerator Timedela()
    {
        yield return new WaitForSeconds(0.1f);
        ColliderEvent2.Invoke();
    }
}

