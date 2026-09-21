using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UserInputManager_Script : MonoBehaviour
{
    private string _endpoint;
    public string CurrentLetterdata;
    //public GameObject LoginPanel;
    private TMP_InputField UserInput;
    //public TMP_Text Error_Text;
    public TMP_InputField Email_Input, Password_Input ,Entername_input , PhoneNumber_Input, Anchor_Input;
    //private TestingDataHandler apiHandler_Script;
    [Space(20)]
    public UnityEvent LoginSuccess_Event, LoginError_Event, LogoutSuccess_Event, LogoutError_Event;
    // Start is called before the first frame update
    void Start()
    {
        Initialization();        
    }

    private void Initialization()
    {
        ResetInputfields();
       
    }

    #region Keyboard Inputs

    public void PhoneNumberSelected_Event()
    {
        UserInput = PhoneNumber_Input;
        UserInput.text = PhoneNumber_Input.text;
    }
    public void EmailInputSelected_Event()
    {
        //Error_Text.text = string.Empty;
        UserInput = Email_Input;
        UserInput.text = Email_Input.text;
    }
    public void EnterNameInputSelect_event()
    {
        UserInput = Entername_input;
        UserInput.text = Entername_input.text;
    }
    public void PasswordInputSelected_Event()
    {
        //Error_Text.text = string.Empty;
        UserInput = Password_Input;
        UserInput.text = Password_Input.text;
    }
    public void AnchorInputSelected_Event()
    {
        //Error_Text.text = string.Empty;
        UserInput = Anchor_Input;
        UserInput.text = Anchor_Input.text;
    }


    public void AddtextToUserdata()
    {
        UserInput.text += CurrentLetterdata;
    }

    public void SpaceButtonClicked_Event()
    {
        UserInput.text += " ";
    }

    public void ClearButtonSelected_Event()
    {
        if(UserInput.text.Length > 0)
        {
            UserInput.text = UserInput.text.Substring(0, UserInput.text.Length - 1);
        }
        
    }

    private void ResetInputfields()
    {       
            if (Email_Input != null)
            {
                Email_Input.text = string.Empty;
            }
            if (Password_Input != null)
            {
                Password_Input.text = string.Empty;
            }
            if (Entername_input != null)
            {
                Entername_input.text = string.Empty;
            }
            if (PhoneNumber_Input != null)
            {
                PhoneNumber_Input.text = string.Empty;
            }
            if (Anchor_Input != null)
            {
                Anchor_Input.text = string.Empty;
            }
       

        #endregion
    }
    

}
