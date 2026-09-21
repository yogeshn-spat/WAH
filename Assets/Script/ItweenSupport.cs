using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ItweenSupport : MonoBehaviour
{
    public Transform targetPosition; 
    public float moveDuration = 2.0f; 
   
   
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
        "position", targetPosition.position, 
          "time", moveDuration, 
          "easetype", iTween.EaseType.easeInOutSine, 
          "oncomplete", "OnMoveComplete" 
      ));
        iTween.RotateTo(this.gameObject, iTween.Hash(
           "rotation", targetPosition,
           "islocal", true, //local to parent
           "time", 2, //time
           "easetype", "easeOutExpo", //with easing
           "delay", .1f //after 3 seconds
       ));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
