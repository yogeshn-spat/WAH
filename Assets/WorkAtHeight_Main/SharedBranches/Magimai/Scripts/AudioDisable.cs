using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioDisable : MonoBehaviour
{
    [Tooltip("Put 0.6 for Pick and Place Audio")]
    public float TimeGiven;
    // Start is called before the first frame update
    
    void OnEnable()
    {
        Invoke("DisableGameObject", TimeGiven);
    }

    void Start()
    {
       // gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableGameObject()
    {
        gameObject.SetActive(false);
    }

}
