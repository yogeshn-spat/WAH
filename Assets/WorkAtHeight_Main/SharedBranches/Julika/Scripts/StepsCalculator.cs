using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StepsCalculator : MonoBehaviour
{
    public int Score = 0;
    public UnityEvent PanelEnableEvent, PanelEnableEvent2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreUpdate()
    {
        Score++;
        //Debug.Log(Score);

        if(Score == 2)
        {
            PanelEnableEvent.Invoke();
        }
        if(Score == 5)
        {
            PanelEnableEvent2.Invoke();
        }
    }


}
