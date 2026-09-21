using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.UI;
using TMPro;
using HindiFontReplacer;

[RequireComponent(typeof(CharReplacerTamil))]
[RequireComponent(typeof(CharReplacerHindi))]

public class TextViewerrWitLang : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    public CharReplacerTamil CtScript;
    public CharReplacerHindi ChScript;

    public TMP_FontAsset FontEnglish, FontHindi, FontTamil;
    public float Engfontsize, Hinfontsize, Tamfontsize;

    [TextArea(10, 7)]
    public string[] currentlangsteps = { };
    [TextArea(10, 7)]
    public string[] stepseng = { };
    [TextArea(10, 7)]
    public string[] stepshin = { };
    [TextArea(10, 7)]
    public string[] stepstam = { };

    private int currentStep = 0;
    [HideInInspector]
    public int language;
    private int LanguageID;

    public void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        CtScript = GetComponent<CharReplacerTamil>();
        ChScript = GetComponent<CharReplacerHindi>();
        LangSelection();
        if (CtScript != null && language == 3)
        {
            CtScript = GetComponent<CharReplacerTamil>();
            CtScript.enabled = true;
        }
        if (ChScript != null && language == 2)
        {
            ChScript = GetComponent<CharReplacerHindi>();
            ChScript.enabled = true;
        }
        textMeshPro.text = currentlangsteps[currentStep];

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextStep();
        }

    }
    public void LangSelection()
    {
        language = PlayerPrefs.GetInt("LanguageID", LanguageID);

        switch (language)
        {
            case 1:
                currentlangsteps = stepseng;
                textMeshPro.font = FontEnglish;
                textMeshPro.fontSize = Engfontsize;
                DisplayCurrentStep();
                break;

            case 2:
                currentlangsteps = stepshin;
                textMeshPro.font = FontHindi;
                textMeshPro.fontSize = Hinfontsize;
                DisplayCurrentStep();
                break;

            case 3:
                currentlangsteps = stepstam;
                textMeshPro.font = FontTamil;
                textMeshPro.fontSize = Tamfontsize;
                DisplayCurrentStep();
                break;
        }
    }

    public void NextStep()
    {
        currentStep = currentStep + 1;
        DisplayCurrentStep();
        if (CtScript != null)
        {
            CtScript.Start();
        }

        if (ChScript != null)
        {
            ChScript.Start();
        }
    }

    void DisplayCurrentStep()
    {
        if (language == 2)
        {
            ChScript.Start();
        }
        if (language == 3)
        {
            CtScript.Start();
        }
        textMeshPro.text = currentlangsteps[currentStep];
    }

}
