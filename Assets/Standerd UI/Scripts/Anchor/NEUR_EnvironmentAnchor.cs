using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEUR_EnvironmentAnchor : MonoBehaviour
{
    public Transform _Environment;
    OVRSpatialAnchor workingAnchor;
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.GetComponent<HeadCollisionDetector>() != null)
        {

            if (workingAnchor != null)
            {
                Vector3 environmentPos = workingAnchor.transform.position;
                environmentPos.y = _Environment.transform.position.y;

                _Environment.position = environmentPos;
                _Environment.rotation = workingAnchor.transform.rotation;

            }
        }

    }

    public void GetAnchor()
    {
        workingAnchor = GameObject.Find("DemoAnchorPrefabs(Clone)").GetComponent<OVRSpatialAnchor>();
    }
}
