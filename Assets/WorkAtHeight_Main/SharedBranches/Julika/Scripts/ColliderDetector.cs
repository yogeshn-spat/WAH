using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderDetector : MonoBehaviour
{
    public string ColliderTagName;
    public UnityEvent ColliderEvent;
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
        if (other.gameObject.CompareTag(ColliderTagName))
        {
            ColliderEvent.Invoke();
        }
    }
}
