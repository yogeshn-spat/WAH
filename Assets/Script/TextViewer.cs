using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextViewer : MonoBehaviour
{
    public string textName;
    private bool isFirsttime=true;
    public TextMeshProUGUI textMeshPro;
 

    public void OnEnable()
    {
        if(isFirsttime ) 
        {
            textName = gameObject.name;
            isFirsttime=false;
        }
       
    }
    public void FetchObjectName()
    {
        if (textMeshPro != null)

        {
            textMeshPro.text = textName;
        }
    }
}
