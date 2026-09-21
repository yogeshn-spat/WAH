using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HindiFontReplacer;

[RequireComponent(typeof(CharReplacerTamil))]
[RequireComponent(typeof(CharReplacerHindi))]

public class LangSelection : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    public CharReplacerTamil CtScript;
    public CharReplacerHindi ChScript;

    public TMP_FontAsset FontEnglish, FontHindi, FontTamil;
    public float Engfontsize, Hinfontsize, Tamfontsize;


[TextArea(10, 7)]
    public string currentlangsteps;
    [TextArea(10, 7)]
    public string stepseng;
    [TextArea(10, 7)]
    public string stepshin;
    [TextArea(10, 7)]
    public string stepstam;

    [HideInInspector]
    public int language;
    private int LanguageID;

    void Awake()
    {
        CtScript = GetComponent<CharReplacerTamil>();
        ChScript = GetComponent<CharReplacerHindi>();
        CtScript.enabled = false;
        ChScript.enabled = false;
    }

    public void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        LangSelect();
        if (CtScript != null && language == 3)
        {
            CtScript.enabled = true;
            CtScript.Start();
        }
        if (ChScript != null && language == 2)
        {
            ChScript.enabled = true;
            ChScript.Start();
        }
        textMeshPro.text = currentlangsteps;

    }

    public void LangSelect()
    {
        language = PlayerPrefs.GetInt("LanguageID", LanguageID);

        switch (language)
        {
            case 1:
                currentlangsteps = stepseng;
                textMeshPro.font = FontEnglish;
                textMeshPro.fontSize = Engfontsize;
                break;

            case 2:
                currentlangsteps = stepshin;
                textMeshPro.font = FontHindi;
                textMeshPro.fontSize = Hinfontsize;            
                break;

            case 3:
                currentlangsteps = stepstam;
                textMeshPro.font = FontTamil;
                textMeshPro.fontSize = Tamfontsize;                
                break;
        }
    }
}
