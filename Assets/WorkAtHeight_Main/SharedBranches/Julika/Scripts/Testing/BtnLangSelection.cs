using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HindiFontReplacer;

public class BtnLangSelection : MonoBehaviour
{
    public TextMeshPro textMeshPro;

    public CharReplacerTamil CtScript;
    public CharReplacerHindi ChScript;

    public TMP_FontAsset FontEnglish, FontHindi, FontTamil;
    public float Engfontsize, Hinfontsize, Tamfontsize;


[TextArea(10, 7)]
    public string steps;
    [TextArea(10, 7)]
    public string stepseng;
    [TextArea(10, 7)]
    public string stepshin;
    [TextArea(10, 7)]
    public string stepstam;

    [HideInInspector]
    public int language;
    private int LanguageID;

    public void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        CtScript = GetComponent<CharReplacerTamil>();
        ChScript = GetComponent<CharReplacerHindi>();
        LangSelect();
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
        textMeshPro.text = steps;

    }

    public void LangSelect()
    {
        language = PlayerPrefs.GetInt("LanguageID", LanguageID);

        switch (language)
        {
            case 1:
                steps = stepseng;
                textMeshPro.font = FontEnglish;
                textMeshPro.fontSize = Engfontsize;
                DisplayCurrentStep();
                break;

            case 2:
                steps = stepshin;
                textMeshPro.font = FontHindi;
                textMeshPro.fontSize = Hinfontsize;
                ChScript.Start();
                DisplayCurrentStep();
                break;

            case 3:
                steps = stepstam;
                textMeshPro.font = FontTamil;
                textMeshPro.fontSize = Tamfontsize;
                CtScript.Start();
                DisplayCurrentStep();
                break;
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
        textMeshPro.text = steps;
    }
}
