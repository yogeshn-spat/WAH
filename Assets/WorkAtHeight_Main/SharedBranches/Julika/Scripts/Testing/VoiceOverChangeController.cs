using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VoiceOverChangeController : MonoBehaviour
{
    public AudioSource audios;

    public AudioClip[] audiostep;

    private int currentaudiovalue = 0;

    void Awake()
    {
        audios = GetComponent<AudioSource>();
    }
    void Start()
    {
        
        DisplayCurrentAudio();
    }

    void Update()
    {
        
    }

    public void buttonclickAudio()
    {
        NextButtonClickAudio();
    }

    void DisplayCurrentAudio()
    {
        audios.clip = audiostep[currentaudiovalue];
        audios.Play();
    }

    void NextButtonClickAudio()
    {
        currentaudiovalue = currentaudiovalue + 1;
        DisplayCurrentAudio();

    }
}
