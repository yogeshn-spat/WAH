using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ResultText1 : MonoBehaviour
{
    public string textName, textNameH, textNameT;
    private bool isFirsttime = true;
    private bool isLasttime = true;
    public List<TextMeshProUGUI> StepsText = new List<TextMeshProUGUI>();
    public int language;
    private int LanguageID;
    public UnityEvent Event,Event1;

    public TMP_FontAsset FontTamil,FontHindi;
    public void OnEnable()
    {
        if (isFirsttime)
        {
            textName = gameObject.name;
            isFirsttime = false;
            language = PlayerPrefs.GetInt("LanguageID", LanguageID);
            FetchObjectName();
            if (language == 2)
            {
                Event.Invoke();
            }

            if (language == 3)
            {
                Event1.Invoke();
            }

        }


    }
    public void FetchObjectName()
    {

        switch (language)
        {
            case 1:
                if (StepsText != null && string.IsNullOrEmpty(StepsText[0].text) && isLasttime)
                {
                    StepsText[0].text = textName;
                    isLasttime = false;
                    GameObject R11 = GameObject.Find("R11");
                    R11.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[1].text) && isLasttime)
                {
                    StepsText[1].text = textName;
                    isLasttime = false;
                    GameObject R22 = GameObject.Find("R22");
                    R22.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[2].text) && isLasttime)
                {
                    StepsText[2].text = textName;
                    isLasttime = false;
                    GameObject R33 = GameObject.Find("R33");
                    R33.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[3].text) && isLasttime)
                {
                    StepsText[3].text = textName;
                    isLasttime = false;
                    GameObject R44 = GameObject.Find("R44");
                    R44.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[4].text) && isLasttime)
                {
                    StepsText[4].text = textName;
                    isLasttime = false;
                    GameObject R55 = GameObject.Find("R55");
                    R55.name = textName + "Images";
                }
                break;

            case 2:

                if (StepsText != null && string.IsNullOrEmpty(StepsText[0].text) && isLasttime)
                {
                    StepsText[0].font = FontHindi;
                    TranslationToHindi();
                    StepsText[0].text = textNameH;
                    isLasttime = false;
                    GameObject R11 = GameObject.Find("R11");
                    R11.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[1].text) && isLasttime)
                {
                    StepsText[1].font = FontHindi;
                    TranslationToHindi();
                    StepsText[1].text = textNameH;
                    isLasttime = false;
                    GameObject R22 = GameObject.Find("R22");
                    R22.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[2].text) && isLasttime)
                {
                    StepsText[2].font = FontHindi;
                    TranslationToHindi();
                    StepsText[2].text = textNameH;
                    isLasttime = false;
                    GameObject R33 = GameObject.Find("R33");
                    R33.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[3].text) && isLasttime)
                {
                    StepsText[3].font = FontHindi;
                    TranslationToHindi();
                    StepsText[3].text = textNameH;
                    isLasttime = false;
                    GameObject R44 = GameObject.Find("R44");
                    R44.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[4].text) && isLasttime)
                {
                    StepsText[4].font = FontHindi;
                    TranslationToHindi();
                    StepsText[4].text = textNameH;
                    isLasttime = false;
                    GameObject R55 = GameObject.Find("R55");
                    R55.name = textName + "Images";
                }
                break;

            case 3:
                if (StepsText != null && string.IsNullOrEmpty(StepsText[0].text) && isLasttime)
                {
                    StepsText[0].font = FontTamil;
                    TranslationToTamil();
                    StepsText[0].text = textNameT;
                    isLasttime = false;
                    GameObject R11 = GameObject.Find("R11");
                    R11.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[1].text) && isLasttime)
                {
                    StepsText[1].font = FontTamil;
                    TranslationToTamil();
                    StepsText[1].text = textNameT;
                    isLasttime = false;
                    GameObject R22 = GameObject.Find("R22");
                    R22.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[2].text) && isLasttime)
                {
                    StepsText[2].font = FontTamil;
                    TranslationToTamil();
                    StepsText[2].text = textNameT;
                    isLasttime = false;
                    GameObject R33 = GameObject.Find("R33");
                    R33.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[3].text) && isLasttime)
                {
                    StepsText[3].font = FontTamil;
                    TranslationToTamil();
                    StepsText[3].text = textNameT;
                    isLasttime = false;
                    GameObject R44 = GameObject.Find("R44");
                    R44.name = textName + "Images";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[4].text) && isLasttime)
                {
                    StepsText[4].font = FontTamil;
                    TranslationToTamil();
                    StepsText[4].text = textNameT;
                    isLasttime = false;
                    GameObject R55 = GameObject.Find("R55");
                    R55.name = textName + "Images";
                }
                break;


            default:

                break;
        }

    }

    public void TranslationToHindi()
    {
        switch(textName)
        {
            case "SafetyNet":

                textNameH = "सुरक्षा तंत्र";
                break;

            case "BasePlate":
                textNameH = "बेस प्लेट";
                break;

            case "GuardRail":
                textNameH = "रेलिंग";
                break;
            case "Plank":

                textNameH = "काष्ठफलक";
                break;

            case "CementBag":
                textNameH = "सीमेंटबैग";
                break;

            case "Rod":
                textNameH = "छड़";
                break;

            case "LeaningHuman":
                textNameH = "झुकावमानव";
                break;

            case "GuardRail(Floor-Level)":
                textNameH = "गार्डरेल(फर्श-स्तर)";
                break;

            case "Scaffold Platform":
                textNameH = "मचान मंच";
                break;
        }
    }

    public void TranslationToTamil()
    {
        switch (textName)
        {
            case "SafetyNet":
                textNameT = "பாதுகாப்பு வலை";
                break;

            case "BasePlate":
                textNameT = "அடிதட்டுகள்";
                break;

            case "GuardRail":
                textNameT = "தடுப்புகள்";
                break;
            case "Plank":

                textNameT = "பலகை";
                break;

            case "CementBag":
                textNameT = "சிமெண்ட் பை";
                break;

            case "Rod":
                textNameT = "தடுப்பு";
                break;

            case "LeaningHuman":
                textNameT = "மனிதர்";
                break;

            case "GuardRail(Floor-Level)":
                textNameT = "தடுப்புகள்(தரை-நிலை)";
                break;

            case "Scaffold Platform":
                textNameT = "சாரக்கட்டு மேடை";
                break;
        }
    }
}