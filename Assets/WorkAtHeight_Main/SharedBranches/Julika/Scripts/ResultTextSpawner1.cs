using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ResultTextSpawner1 : MonoBehaviour
{
    public string textName;
    private bool isFirsttime = true;
    private bool isLasttime = true;
    //public GameObject Img;
    public List<TextMeshProUGUI> StepsText = new List<TextMeshProUGUI>();

    private void Start()
    {
        FetchObjectName();

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
        if (StepsText != null && string.IsNullOrEmpty(StepsText[0].text)&& isLasttime)
        {
            StepsText[0].text = textName;
            isLasttime = false;
            GameObject R1 = GameObject.Find("R11");
            R1.name = textName + "Images";
        }
        if (StepsText != null && string.IsNullOrEmpty(StepsText[1].text) && isLasttime)
        {
            StepsText[1].text = textName;
            isLasttime = false;
            GameObject R2 = GameObject.Find("R22");
            R2.name = textName + "Images";
        }
        if (StepsText != null && string.IsNullOrEmpty(StepsText[2].text) && isLasttime)
        {
            StepsText[2].text = textName;
            isLasttime = false;
            GameObject R3 = GameObject.Find("R33");
            R3.name = textName + "Images";
        }
        if (StepsText != null && string.IsNullOrEmpty(StepsText[3].text) && isLasttime)
        {
            StepsText[3].text = textName;
            isLasttime = false;
            GameObject R4 = GameObject.Find("R44");
            R4.name = textName + "Images";
        }
        if (StepsText != null && string.IsNullOrEmpty(StepsText[4].text) && isLasttime)
        {
            StepsText[4].text = textName;
            isLasttime = false;
            GameObject R5 = GameObject.Find("R55");
            R5.name = textName + "Images";
        }
    }
}
