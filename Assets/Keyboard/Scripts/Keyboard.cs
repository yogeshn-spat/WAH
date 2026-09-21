using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Keyboard : MonoBehaviour
{
    public TMP_InputField inputField;  // Instance
    public TMP_InputField Username;  // Instance
    public TMP_InputField Password;  // Instance
    public GameObject normalButtons;
    public GameObject capsButtons;
    private bool caps;
    //public GameObject Enterdis;
   // public GameObject Enterena;
    // Start is called before the first frame update
    void Start()
    {
        caps = false;
    }

    public void Insertchar(string c)
    {
        inputField.text += c;
    }

    public void Deletechar()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }
    public void Insertspace()
    {
        inputField.text += " ";
    }
    public void CapsPressed()
    {
        if (!caps)
        {
            normalButtons.SetActive(false);
            capsButtons.SetActive(true);
            caps = true;
        }
        else
        {
            normalButtons.SetActive(true);
            capsButtons.SetActive(false);
            caps = false;
        }
    }

    public void SelectUsername()
    {
        inputField = Username;
    }

    public void SelectPassword()
    {
        inputField = Password;
    }

    public void OnEnter()
    {
        /*if(inputField.text.Length > 0)
        {
            //Enterdis.gameObject.SetActive(false);
           // Enterena.gameObject.SetActive(true);
        }
        else
        {
            return;
        }*/

        if(inputField == Username)
        {
            inputField = Password;
        }
        else 
        {
            gameObject.SetActive(false);
        }
        

    }

}
