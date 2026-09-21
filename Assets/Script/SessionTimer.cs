using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SessionTimer : MonoBehaviour
{
    public float elapsedTime = 0f;
    private DateTime startDateTime;
    public  bool isSessionTimerRunning = false,ResetTimer = false;
    public static SessionTimer instance;
    public float sessionStartTime = 0f;
    private bool startTime=true;
    // Optional: You can reference a UI Text element to display the timer
    //public TextMeshProUGUI timerText;
    void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
    void Start()
    {
       
    }
    void Update()
    {
        //if (timerText == null)
        //{
        //    timerText = GameObject.Find("SessionTimeGO").GetComponent<TextMeshProUGUI>();
        //}
        if (isSessionTimerRunning)
        {

            if (startDateTime == DateTime.MinValue)
            {
                startDateTime = DateTime.Now;
                // Log the start time in the desired format
                //Debug.Log("Start Time: " + startDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
        if (ResetTimer)
        {
            elapsedTime = 0f;
            startDateTime = DateTime.MinValue;
            isSessionTimerRunning = true;
            UpdateTimerDisplay();
            ResetTimer = false;
        }
    }

    void UpdateTimerDisplay()
    {
        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        //Debug.Log(string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds));
        // Update your timer display here if needed

        //if (timerText != null)
        //    timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

   
    public float GetTotalTime()
    {
        return elapsedTime;
    }

    public void ResetTime()
    {
        ResetTimer = true;
    }
    public void SessionStopTimer()
    {
        isSessionTimerRunning = false;
    }
}
