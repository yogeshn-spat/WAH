using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperLowerCase_Manager : MonoBehaviour
{
    public GameObject LowerCaseLetters_Obj, UpperCaseLetters_Obj, Symbols_Obj;  
    private bool UpperCase_Bool, LowerCase_Bool, Symbols_Bool;

    public void OnEnable()
    {
        UpperCase_Bool = false;
        LowerCase_Bool = true;        
        Symbols_Bool = false;
        LowerCaseLetters_Obj.SetActive(true);
        UpperCaseLetters_Obj.SetActive(false);
        Symbols_Obj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CapsButtonPressedEvent()
    {
        Symbols_Obj.SetActive(false);
        if(LowerCase_Bool)
        {
            LowerCaseLetters_Obj.SetActive(false);
            UpperCaseLetters_Obj.SetActive(true);
            LowerCase_Bool = false;
            UpperCase_Bool = true;
        }
        else if (UpperCase_Bool)
        {
            LowerCaseLetters_Obj.SetActive(true);
            UpperCaseLetters_Obj.SetActive(false);
            LowerCase_Bool = true;
            UpperCase_Bool = false;
        }
    }

    public void SymbolsButtonPressedEvent()
    {
        if(Symbols_Bool)
        {
            if(LowerCase_Bool)
            {
                Symbols_Obj.SetActive(false);
                LowerCaseLetters_Obj.SetActive(true);                
                Symbols_Bool = false;
            }
            else
            {
                Symbols_Obj.SetActive(false);
                UpperCaseLetters_Obj.SetActive(true);                
                Symbols_Bool = false;
            }           

        }
        else
        {
            if (LowerCase_Bool)
            {
                LowerCaseLetters_Obj.SetActive(false);
                Symbols_Obj.SetActive(true);
                Symbols_Bool = true;
            }
            else
            {
                UpperCaseLetters_Obj.SetActive(false);
                Symbols_Obj.SetActive(true);
                Symbols_Bool = true;
            }
        }
    }

    private void resetEverything()
    {
        LowerCaseLetters_Obj.SetActive(false);
        UpperCaseLetters_Obj.SetActive(false);
        Symbols_Obj.SetActive(false);
    }
}
