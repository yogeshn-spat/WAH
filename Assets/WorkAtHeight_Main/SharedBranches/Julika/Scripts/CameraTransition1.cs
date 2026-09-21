using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition1 : MonoBehaviour
{
    public Transform CameraNextPosition;
    public Transform Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraMovement2()
    {
        StartCoroutine(TimeDelayss2());
    }

    public IEnumerator TimeDelayss2() 
    {
        yield return new WaitForSeconds(1.5f);
        Camera.transform.position = CameraNextPosition.position;
        Camera.transform.rotation = CameraNextPosition.rotation;
    }
}
