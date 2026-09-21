using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class AudioPlayerEnabler : MonoBehaviour
{
    private AudioSource CurrentaudioSource;
    private AudioClip audioClip1;
    private AudioSource audioClip2;
    public GameObject NextAudio;


    void Start()
    {
        CurrentaudioSource = gameObject.GetComponent<AudioSource>();
        audioClip1 = CurrentaudioSource.clip;

        audioClip2 = NextAudio.GetComponent<AudioSource>();
        StartCoroutine(NextAudioPlayer(audioClip1));
    }

    public void Repeat()
    {
        CurrentaudioSource = gameObject.GetComponent<AudioSource>();
        audioClip1 = CurrentaudioSource.clip;
        audioClip2 = NextAudio.GetComponent<AudioSource>() ;
        StartCoroutine(NextAudioPlayer(audioClip1));
    }


    public IEnumerator NextAudioPlayer(AudioClip Sound)
    {

        yield return new WaitUntil(() => CurrentaudioSource.isPlaying == false);
        NextAudio.SetActive(true);
        audioClip2.Play();
        //NextAudioEnabler.Play();
    }


}
