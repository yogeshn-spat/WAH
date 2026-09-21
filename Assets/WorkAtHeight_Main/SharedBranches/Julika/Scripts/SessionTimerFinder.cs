using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionTimerFinder : MonoBehaviour
{
    public SessionTimer sessionTimer;
    void Start()
    {
        sessionTimer = GameObject.Find("SessionTimer").GetComponent<SessionTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetTime()
    {
        sessionTimer.ResetTime();
    }
}
