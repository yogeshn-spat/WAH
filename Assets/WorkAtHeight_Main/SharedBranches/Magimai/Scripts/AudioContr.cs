using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioContr : MonoBehaviour
{

    private AudioSource[] _audioSources;
    public AudioClip audioss;
    private void Start()
    {
       
      
    }
    public void Pause()
    {
        AudioListener.volume = 0;
    }
    public void ResetAudio()
    {
        AudioListener.volume = 1;
    }

    public void Resume()
    {
        AudioListener.volume = 1;
    }
    public void LoopAudio()
    {
        _audioSources = _audioSources = GameObject.FindGameObjectsWithTag("SoundSpots").Select(x => x.GetComponent<AudioSource>()).ToArray();
        _audioSources[0].Play();
      


    }
}
