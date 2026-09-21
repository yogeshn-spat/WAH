using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventEnable : MonoBehaviour
{
    public UnityEvent eventenable;
    public string TagName;
    public float TimeDelay;
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
       if( other.gameObject.CompareTag(TagName))
        {
            StartCoroutine(Delayy());
        }
    }

    public IEnumerator Delayy()
    {
        yield return new WaitForSeconds(TimeDelay);
        eventenable.Invoke();
    }
}
