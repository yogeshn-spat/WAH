using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using Unity.VisualScripting;
//using static Unity.VisualScripting.Icons;

public class ResultTextSpawner : MonoBehaviour
{
    public string textName;
    private bool isFirsttime = true;
    private bool isLasttime = true;
    public List<TextMeshProUGUI> StepsText = new List<TextMeshProUGUI>();
    private int language;

    private void Start()
    {
        FetchObjectName();
        //language= PlayerPrefs.GetInt("LanguageID", 0);

    }
    // Start is called before the first frame update

    public void OnEnable()
    {
        if (isFirsttime)
        {
            textName = gameObject.name;
            isFirsttime = false;
        }
       

    }
    public void FetchObjectName()
    {
                if (StepsText != null && string.IsNullOrEmpty(StepsText[0].text) && isLasttime)
                {
                    StepsText[0].text = textName;
                    isLasttime = false;
                    GameObject R1 = GameObject.Find("R1");
                    R1.name = textName + "Image";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[1].text) && isLasttime)
                {
                    StepsText[1].text = textName;
                    isLasttime = false;
                    GameObject R2 = GameObject.Find("R2");
                    R2.name = textName + "Image";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[2].text) && isLasttime)
                {
                    StepsText[2].text = textName;
                    isLasttime = false;
                    GameObject R3 = GameObject.Find("R3");
                    R3.name = textName + "Image";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[3].text) && isLasttime)
                {
                    StepsText[3].text = textName;
                    isLasttime = false;
                    GameObject R4 = GameObject.Find("R4");
                    R4.name = textName + "Image";
                }
                if (StepsText != null && string.IsNullOrEmpty(StepsText[4].text) && isLasttime)
                {
                    StepsText[4].text = textName;
                    isLasttime = false;
                    GameObject R5 = GameObject.Find("R5");
                    R5.name = textName + "Image";
                }
        
        
    }


}
