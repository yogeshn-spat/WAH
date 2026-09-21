using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public GameObject[] UICardElements;

    private GameObject[] AllScriptedObjects;

    public int LanguageID = 0;
    // Start is called before the first frame update
    void Start()
    {
        LoadScriptsIntoObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScriptsIntoObjects()
    {
        foreach (GameObject GO in UICardElements)
        {
            if (GO.GetComponent<LanguageAgent>() == null)
            {
                GO.AddComponent<LanguageAgent>();
            }

            else
            {
                //Do nothing
            }
        }
    }

    public void EnglishButtonClicked()
    {
        LanguageID = 1;
        PlayerPrefs.SetInt("LanguageID", LanguageID);
    }

    public void HindiButtonClicked()
    {
        LanguageID = 2;
        PlayerPrefs.SetInt("LanguageID", LanguageID);
    }

    public void TamilButtonClicked()
    {
        LanguageID = 3;
        PlayerPrefs.SetInt("LanguageID", LanguageID);
    }

   /* public void AmericanButtonClicked()
    {
        LanguageID = 4;
        PlayerPrefs.SetInt("LanguageID", LanguageID);
    }*/

    public void English2()
    {
        LanguageID = 1;
        PlayerPrefs.SetInt("LanguageID", LanguageID);
        foreach (GameObject GO in UICardElements)
        {
            GO.GetComponent<LanguageAgent>().ChangeLanguageInTheMiddle();
        }    
    }

    public void Hindi2()
    {
        LanguageID = 2;
        PlayerPrefs.SetInt("LanguageID", LanguageID);
        foreach (GameObject GO in UICardElements)
        {
            GO.GetComponent<LanguageAgent>().ChangeLanguageInTheMiddle();
        }
    }

    public void Tamil2()
    {
        LanguageID = 3;
        PlayerPrefs.SetInt("LanguageID", LanguageID);
        foreach (GameObject GO in UICardElements)
        {
            GO.GetComponent<LanguageAgent>().ChangeLanguageInTheMiddle();
        }
    }


    /* public void  American2()
     {
         LanguageID= 4;
         PlayerPrefs.SetInt("LanguageID", LanguageID);
         foreach(GameObject GO in UICardElements)
         {
             GO.GetComponent <LanguageAgent>().ChangeLanguageInTheMiddle();  
         }
     }*/

    public void AddGameObjectinUICardElement(GameObject newGameObject)
    {
        // Create a new array with one more element than the original
        GameObject[] newArray = new GameObject[UICardElements.Length + 1];

        // Copy the elements from the old array to the new array
        for (int i = 0; i < UICardElements.Length; i++)
        {
            newArray[i] = UICardElements[i];
        }

        // Add the new GameObject to the last position in the new array
        newArray[newArray.Length - 1] = newGameObject;

        // Replace the old array with the new array
        UICardElements = newArray;
        LoadScriptsIntoObjects();
    }
}
