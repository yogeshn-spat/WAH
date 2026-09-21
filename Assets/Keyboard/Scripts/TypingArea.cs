using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingArea : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject leftTypingHand;
    public GameObject rightTypingHand;

/*    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag== "Left" || other.gameObject.tag == "Right")
        {
            GameObject hand = other.GetComponentInParent<Hand>().gameObject;
            if (hand == null) return;
            *//*if (hand == leftHand)
            {
                leftTypingHand.SetActive(true);
            }
            else if (hand == rightHand)
            {
                rightTypingHand.SetActive(true);
            }*//*
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Left" || other.gameObject.tag == "Right")
        {
            GameObject hand = other.GetComponentInParent<Hand>().gameObject;
            if (hand == null) return;
          *//*  if (hand == leftHand)
            {
                leftTypingHand.SetActive(false);
            }
            else if (hand == rightHand)
            {
                rightTypingHand.SetActive(false);
            }*//*
        }
    }*/
}