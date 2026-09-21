using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static DataHandler;

public class AnchorAuthenticationController : MonoBehaviour
{
    public DataHandler dataHandler;

    public TMP_InputField passwordInputField;
    public GameObject passwordIncorrectText;
    public UnityEvent CreateAnchorEvent, deleteAnchorEvent;

    public TextMeshProUGUI companyNameField;

    private void Start()
    {
        companyNameField.text = dataHandler.companyNameOfUser;
    }
    public void DeleteAnchorwithAuthentication()
    {
        dataHandler.nameOfUser = PlayerPrefs.GetString("UserName");
        dataHandler.passwordOfUser = PlayerPrefs.GetString("Password");
        
        if (dataHandler.passwordOfUser == passwordInputField.text)
        {
            deleteAnchorEvent.Invoke();
        }
        else
        {   
            //password wrong warning text
            passwordIncorrectText.SetActive(true);
        }

    }

    public void CreateAnchorwithAuthentication()
    {
        dataHandler.nameOfUser = PlayerPrefs.GetString("UserName");
        dataHandler.passwordOfUser = PlayerPrefs.GetString("Password");

        if (dataHandler.passwordOfUser == passwordInputField.text)
        {
            CreateAnchorEvent.Invoke();
        }
        else
        {
            //password wrong warning text
            passwordIncorrectText.SetActive(true);
        }

    }
    public void MakeEmptyField()
    {
        passwordInputField.text = null;
    }
    public void CreateAnchorEventInvoke()
    {
        CreateAnchorEvent.Invoke();
    }
}
