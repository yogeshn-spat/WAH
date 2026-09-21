using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPositionManager : MonoBehaviour
{
    public GameObject ColliderObject;
    public UnityEvent ColliderEvent;
    public UnityEvent ColliderEvent2;
    public float moveDuration = 2.0f;
    // 1)

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ColliderObject)
        {
            ColliderEvent.Invoke();
            //ColliderObject.transform.position = transform.position;
            //ColliderObject.transform.rotation = transform.rotation;
            iTween.MoveTo(ColliderObject, iTween.Hash(
        "position", gameObject.transform.position,
          "time", moveDuration,
          "easetype", iTween.EaseType.easeInOutSine,
          "oncomplete", "OnMoveComplete"
      ));
            iTween.RotateTo(ColliderObject, iTween.Hash(
               "rotation", gameObject.transform,
               "islocal", false, //local to parent
               "time", 2, //time
               "easetype", "easeOutExpo", //with easing
               "delay", .1f //after 3 seconds
           ));
            StartCoroutine(Timedel());
            Debug.Log("COllid");
        }
    }

    public IEnumerator Timedel()
    {
        yield return new WaitForSeconds(moveDuration);
        ColliderEvent2.Invoke();
    }
}

























