using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class SceneController : MonoBehaviour
{
    public int Buttonstatus;
    public GameObject Menu;
    public GameObject OnBoarding;
    public GameObject Learning;
    public GameObject Env;
    private int ButtonCurrentStatus;
    public UnityEvent MenuHomeEvent;
    public UnityEvent ModuleNextEvent;
    public UnityEvent OnBoardingEvent;

    void Start()
    {
        ResetGameSceneGameObjects();

    }


    public void ButtonPressedHome()
    {
        Buttonstatus = 1;
        PlayerPrefs.SetInt("Buttonstatus", Buttonstatus); 
    }


    public void ButtonPressedOnBoarding()
    {
        Buttonstatus = 2;
        PlayerPrefs.SetInt("Buttonstatus", Buttonstatus);
    }


    public void ButtonPressedModule()
    {
        Buttonstatus = 3;
        PlayerPrefs.SetInt("Buttonstatus", Buttonstatus);
        ResetGameSceneGameObjects();
    }



    public void ResetGameSceneGameObjects()
    {

        ButtonCurrentStatus = PlayerPrefs.GetInt("Buttonstatus");
        if (ButtonCurrentStatus == 1)
        {
            MenuHomeEvent.Invoke();
            PlayerPrefs.SetInt("Buttonstatus", 0);
        }

        if (ButtonCurrentStatus == 2)
        {
            OnBoardingEvent.Invoke();
            PlayerPrefs.SetInt("Buttonstatus", 0);
        }

        if (ButtonCurrentStatus == 3)
        {
            ModuleNextEvent.Invoke();
            PlayerPrefs.SetInt("Buttonstatus", 0);
        }

    }


}