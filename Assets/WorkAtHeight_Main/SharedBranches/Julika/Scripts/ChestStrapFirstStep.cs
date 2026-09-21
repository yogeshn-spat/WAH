using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Events;

public class ChestStrapFirstStep : MonoBehaviour
{
    public string TagName1,TagName2;
    public UnityEvent BuckleStepEvent,EnableEvent, BuckleStepEvent2;

    public GameObject NextPosition1, NextPosition2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagName1))
        {
            BuckleStepEvent.Invoke();
            transform.position = NextPosition1.transform.position;
            transform.rotation = NextPosition1.transform.rotation;
            StartCoroutine(Enabler());


        }

        if (other.gameObject.CompareTag(TagName2))
        {
            transform.position = NextPosition2.transform.position;
            transform.rotation = NextPosition2.transform.rotation;
            BuckleStepEvent2.Invoke();

        }
    }

    public IEnumerator Enabler()
    {
        yield return new WaitForSeconds(0.5f);
        EnableEvent.Invoke();
    }
}
