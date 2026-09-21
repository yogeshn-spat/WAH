using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageAgent : MonoBehaviour
{

    public GameObject[] ChildObjects;

    public GameObject English;
    public GameObject Hindi;
    public GameObject Tamil;
    //public GameObject American;

    private int LanguageID;
    void OnEnable()
    {
        LanguageID = PlayerPrefs.GetInt("LanguageID");
        LoadChildrenIntoArray();
        ChangeLanguageByChoice();
    }
    // Start is called before the first frame update
    void Start()
    {
        LanguageID = PlayerPrefs.GetInt("LanguageID");
        LoadChildrenIntoArray();
        ChangeLanguageByChoice();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadChildrenIntoArray()
    {
        int ChildCount = gameObject.transform.childCount;

        ChildObjects = new GameObject[ChildCount];

        for(int i = 0; i < ChildCount; i++)
        {
            ChildObjects[i] = gameObject.transform.GetChild(i).gameObject;
        }

        SortChildrenIntoSlots();
    }

    public void SortChildrenIntoSlots()
    {
        foreach(GameObject GO in ChildObjects)
        {
            if(GO.tag == "English")
            {
                English = GO;
            }

            if (GO.tag == "Hindi")
            {
                Hindi = GO;
            }

            if (GO.tag == "Tamil")
            {
                Tamil = GO;
            }
            /*if(GO.tag == "American")
            {
                American = GO;
            }*/
        }
    }

    public void ChangeLanguageByChoice()
    {
        switch (LanguageID)
        {
            case 0:
                //Do nothing
                break;

            case 1:
                English.SetActive(true);
                Hindi.SetActive(false);
                Tamil.SetActive(false);
               // American.SetActive(false);
                break;

            case 2:
                English.SetActive(false);
                Hindi.SetActive(true);
                Tamil.SetActive(false);
             //   American.SetActive(false);
                break;

            case 3:
                English.SetActive(false);
                Hindi.SetActive(false);
                Tamil.SetActive(true);
              //  American.SetActive(false);
                break;

             case 4:
                English.SetActive(false);
                Hindi.SetActive(false);
                Tamil.SetActive(false);
              //  American.SetActive(true);
                break;
                
        }

    }

    public void ChangeLanguageInTheMiddle()
    {
        LanguageID = PlayerPrefs.GetInt("LanguageID");
        LoadChildrenIntoArray();
        ChangeLanguageByChoice();
    }

}
