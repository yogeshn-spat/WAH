using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InputTextChanger : MonoBehaviour
{
    public GameObject ovrkeyboard; 
    public OVRVirtualKeyboard ovrkeyboardScript;
    public InputField inputField1,inputField2;

    void Start()
    {
       
    }

    void Update()
    {
        ovrkeyboard = GameObject.Find("OVRVirtualKeyboard");
        ovrkeyboardScript = ovrkeyboard.GetComponent<OVRVirtualKeyboard>();
        //ovrkeyboardScript.textCommitField = inputField1;
    }
    public void InputField1()  
    {
        ovrkeyboardScript.textCommitField = inputField1;
    }

    public void InputField2()
    {
        ovrkeyboardScript.textCommitField = inputField2;
    }
}
