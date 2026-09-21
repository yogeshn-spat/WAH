using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitCollider : MonoBehaviour
{
    public GameObject ColliderObject;
    public UnityEvent ColliderEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Jacket"))
        {
            ColliderEvent.Invoke();
            //Debug.Log("Exit");
        }
    }
}
