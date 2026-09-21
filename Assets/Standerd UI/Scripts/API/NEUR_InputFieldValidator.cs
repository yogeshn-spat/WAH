using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NEUR_InputFieldValidator : MonoBehaviour
{

    public enum InputType
    {
        Integer,
        Float,
        Alpha
    }

    public InputType inputType = InputType.Integer;
    public int characterLimit = 10;

    private TMP_InputField inputField;

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.characterLimit = characterLimit;

        inputField.onValueChanged.AddListener(ValidateInput);
    }

    private void ValidateInput(string text)
    {
        string filteredText = text;

        switch (inputType)
        {
            case InputType.Integer:
                filteredText = FilterInteger(text);
                break;
            case InputType.Float:
                filteredText = FilterFloat(text);
                break;
            case InputType.Alpha:
                filteredText = FilterAlpha(text);
                break;
        }

        if (filteredText.Length > characterLimit)
        {
            filteredText = filteredText.Substring(0, characterLimit);
        }

        inputField.text = filteredText;
    }

    private string FilterInteger(string text)
    {
        string filteredText = "";
        foreach (char c in text)
        {
            if (char.IsDigit(c))
            {
                filteredText += c;
            }
        }
        return filteredText;
    }

    private string FilterFloat(string text)
    {
        string filteredText = "";
        bool hasDecimalPoint = false;

        foreach (char c in text)
        {
            if (char.IsDigit(c))
            {
                filteredText += c;
            }
            else if (c == '.' && !hasDecimalPoint)
            {
                filteredText += c;
                hasDecimalPoint = true;
            }
        }
        return filteredText;
    }

    private string FilterAlpha(string text)
    {
        string filteredText = "";
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                filteredText += c;
            }
        }
        return filteredText;
    }
}