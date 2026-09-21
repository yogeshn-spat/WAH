using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChildTextGetter : MonoBehaviour
{
    public string textl;
    // Start is called before the first frame update
    public void OnEnable()
    {
    
        TextMeshProUGUI textLan =  GetComponent<TextMeshProUGUI>();
        textl = textLan.text;
    }

    // Update is called once per frame

}
