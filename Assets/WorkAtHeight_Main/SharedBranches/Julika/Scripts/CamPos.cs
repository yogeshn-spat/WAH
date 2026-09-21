using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPos : MonoBehaviour
{
    public OVRPlayerController playerController;

    private void Start()
    {
    }
    void Update()
    {
        // Move the player (and the camera) to a new position
        playerController.transform.position = new Vector3();
        //Debug.Log(playerController.transform.position);
    } 
}
