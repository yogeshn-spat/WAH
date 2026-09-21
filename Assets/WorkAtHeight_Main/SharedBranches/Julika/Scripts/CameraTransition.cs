using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraTransition : MonoBehaviour
{
    public Transform CameraNextPosition;
    public Transform Camera;
    public UnityEvent AnchorEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraMovement()
    {
        StartCoroutine(TimeDelayss());
    }

    public IEnumerator TimeDelayss() 
    {
        yield return new WaitForSeconds(1.5f);
        Camera.transform.position = CameraNextPosition.position;
        Camera.transform.rotation = CameraNextPosition.rotation;
        AnchorEvent.Invoke();
    }


}
