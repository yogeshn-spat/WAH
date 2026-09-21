using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public class KeyboardEvent : MonoBehaviour
{
    public string keyboardtag = "Alphaletter";
    public GameObject[] objectsWithTag;
    public bool turnOffAlphaLetters;

    public string componentName;



    public void Update()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(keyboardtag);
        foreach (GameObject obj in objectsWithTag)
        {
            Component component = obj.GetComponent(componentName);
            if (component != null)
            {

                if(turnOffAlphaLetters)
                {
                    (component as Behaviour).enabled = false;
                }
                if(!turnOffAlphaLetters)
                {
                    (component as Behaviour).enabled = true;
                }
             
            }
            else
            {
                Debug.LogWarning("Component '" + componentName + "' not found on object '" + obj.name + "'.");
            }
        }
    }

    public void Onletters()
    {
        turnOffAlphaLetters = false;
    }
    public void OnLettersOff()
    {
        turnOffAlphaLetters = true;
    }

}





