using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NEUR_AnchorAPIHandler : MonoBehaviour
{
    public TMP_InputField passwordInputField;
    public GameObject IncorrectCredentials;
    public TMP_Text companyNameField;

    public UnityEvent SubmitSuccessEvent;

    private void OnEnable()
    {
        companyNameField.text = PlayerPrefs.GetString(NEUR_Constant.NEUR_CompanyName, "");
    }
    public void AnchorAuthentication()
    {
        string password = PlayerPrefs.GetString(NEUR_Constant.NEUR_Password, "");

        if (password == passwordInputField.text)
        {
            SubmitSuccessEvent.Invoke();
            ClearInput();
        }
        else
        {
            StartCoroutine(ShowIncorrectCredentials());
        }

    }

    private IEnumerator ShowIncorrectCredentials()
    {
        IncorrectCredentials.SetActive(true);
        yield return new WaitForSeconds(3);
        IncorrectCredentials.SetActive(false);
    }
    
    public void ClearInput()
    {
        passwordInputField.text = string.Empty;

    }
}
