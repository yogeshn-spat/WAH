
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keyboardText_Script : MonoBehaviour
{
    private TMP_Text KeyboardKeyText;
    public UserInputManager_Script UserDataManager_Script;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnEnable()
    {
        UserDataManager_Script = FindObjectOfType<UserInputManager_Script>();
        KeyboardKeyText = gameObject.GetComponentInChildren<TMP_Text>();
        KeyboardKeyText.text = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public void AddTexttoInputfiled()
    {
        UserDataManager_Script.CurrentLetterdata = gameObject.name.ToString();
        UserDataManager_Script.AddtextToUserdata();
    }
}
