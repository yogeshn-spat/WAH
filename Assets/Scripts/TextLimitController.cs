using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextLimitController : MonoBehaviour
{
    public TMP_InputField phoneNumberField;
    public TMP_InputField nameField;
    public int maxCharacterLimit = 15; // Set this based on your requirements

    void Start()
    {
      if (nameField != null)
      {
        nameField.onValueChanged.AddListener(OnNameValueChanged);
      }    
      if (phoneNumberField != null )
      {          
        phoneNumberField.onValueChanged.AddListener(OnPhoneNumberValueChanged);
      }          
    }

    void OnPhoneNumberValueChanged(string newText)
    {
        // Validate phone number input to only allow digits
        string validatedText = ValidatePhoneNumber(newText);

        // Trim to max length if necessary
        if (validatedText.Length > maxCharacterLimit)
        {
            validatedText = validatedText.Substring(0, maxCharacterLimit);
        }

        // Update the input field text with the validated content
        phoneNumberField.text = validatedText;
    }

    void OnNameValueChanged(string newText)
    {
        // Trim to max length if necessary
        if (newText.Length > maxCharacterLimit)
        {
            newText = newText.Substring(0, maxCharacterLimit);
        }

        // Update the name field text
        nameField.text = newText;
    }

    string ValidatePhoneNumber(string input)
    {
        // Filter out non-numeric characters
        string result = "";
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                result += c;
            }
        }

        return result;
    }
}
