using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestStrapConnector : MonoBehaviour
{
    public string ColliderName,ConnectorEndColliderTag;
    public UnityEvent StrapConnectingEvent, EnableEvent,ConnectorEndEvnt;
    public GameObject NextPosition1;
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
        if (other.gameObject.CompareTag(ColliderName))
        {
            transform.position = NextPosition1.transform.position;
            transform.rotation = NextPosition1.transform.rotation;
            StrapConnectingEvent.Invoke();
            StartCoroutine(Enabler());
        }

        if (other.gameObject.CompareTag(ConnectorEndColliderTag))
        {
            ConnectorEndEvnt.Invoke();
        }
    }
    public IEnumerator Enabler()
    {
        yield return new WaitForSeconds(0.5f);
        EnableEvent.Invoke();
    }

}
