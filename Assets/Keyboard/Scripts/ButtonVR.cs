/**************************************************
Copyright : Copyright (c) RealaryVR. All rights reserved.
Description: Script for VR Button functionality.
***************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;
    bool isLeft;
    bool isRight;
    public bool isEmergencyButton;
    
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        isLeft = true; 
        isRight =true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "RightHandkey"|| other.gameObject.name == "Lefthandkey")
        {
           if(isEmergencyButton)
            {
                if (!isPressed)
                {
                    isLeft = false;
                    button.transform.localPosition = new Vector3(0, 0.003f, 0);
                    presser = other.gameObject;
                    onPress.Invoke();
                    sound.Play();
                    isPressed = true;
                }
            }
            else if(isLeft)
            {
                Invoke("DeactiveLeft", .8f);
                if (!isPressed)
                {
                    isLeft = false;
                    button.transform.localPosition = new Vector3(0, 0.003f, 0);
                    presser = other.gameObject;
                    onPress.Invoke();
                    sound.Play();
                    isPressed = true;
                }
            }
           
        }
      
    }
    public void DeactiveLeft()
    {
        isLeft = true;
    }
    public void DeactiveRight()
    {
        isRight = true;
    }
    private void OnTriggerExit(Collider other)
    {
       

        if (other.gameObject.name == "RightHandkey" || other.gameObject.name == "Lefthandkey")
        {
            if(isEmergencyButton)
            {
                if (other.gameObject == presser)
                {
                    isRight = false;
                    button.transform.localPosition = new Vector3(0, 0.015f, 0);
                    onRelease.Invoke();
                    isPressed = false;
                }
            }
          else if (isRight)
            {
                Invoke("DeactiveRight", .5f);
                if (other.gameObject == presser)
                {
                    isRight=false;
                    button.transform.localPosition = new Vector3(0, 0.015f, 0);
                    onRelease.Invoke();

                    isPressed = false;
                }
            }
            
        }
       
    }

    public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.AddComponent<Rigidbody>();
    }

}
