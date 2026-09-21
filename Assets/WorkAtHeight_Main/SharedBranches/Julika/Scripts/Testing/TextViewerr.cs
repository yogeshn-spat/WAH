using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.UI;
using TMPro;
using HindiFontReplacer;


public class TextViewerr : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public GameObject ct;
    public GameObject ch;

    public CharReplacerTamil CtScript;
    public CharReplacerHindi ChScript;

    [TextArea(10,7)]
    public string[] steps = {};
    private int currentStep = 0;

    public void Start()
    {
        ct = GameObject.Find("Tam-txt");
        ch = GameObject.Find("Hin-txt");
        
        if (ct != null)
        {
            CtScript = ct.GetComponent<CharReplacerTamil>();
            CtScript.enabled = true;
        }
        if (ch != null)
        {
            ChScript = ch.GetComponent<CharReplacerHindi>();
            ChScript.enabled = true;
        }
        textMeshPro.text = steps[currentStep];
        DisplayCurrentStep();



    }

    public void buttonclick()
    {
        NextButtonClick();
    }

    void DisplayCurrentStep()
    {
        textMeshPro.text = steps[currentStep];
    }

    void NextButtonClick()
    {
        currentStep = currentStep + 1;
        DisplayCurrentStep();
        if (ct != null)
        {
            CtScript.Start();
        }

        if (ch != null)
        {
            ChScript.Start();
        }
    }

    public void DestroyBoard()
    {
        //controls.DestroyKeyBoard();
    }
}
