using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using System.Collections;
using System;

public class InternetConnectionChecker : MonoBehaviour
{
    public GameObject internetPanel;
    public UnityEvent InternetOnEvent, InternetOffEvent;

    public bool isApiData;
    public UnityEvent isApiDataEvent;
    private const string INTERNET_CHECK_URL = "https://www.google.com";

    private void Start()
    {
        // Start checking the internet connection status in the background
        InvokeRepeating("CheckInternetConnection", 2f, 5f);
    }

    private IEnumerator CheckInternetConnectionCoroutine()
    {
        UnityWebRequest www = UnityWebRequest.Head(INTERNET_CHECK_URL);
        www.timeout = 5; // Set a timeout of 5 seconds

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            HandleInternetOn();
        }
        else
        {
            HandleInternetOff();
            Debug.LogError("Internet connection check failed: " + www.error);
        }
    }

    public void CheckInternetConnection()
    {
        StartCoroutine(CheckInternetConnectionCoroutine());
    }

    private void HandleInternetOn()
    {
        if (internetPanel != null)
        {
            internetPanel.SetActive(false);
        }
        InternetOnEvent.Invoke();

        if (isApiData)
        {
            isApiDataEvent.Invoke();
            isApiData = false;
        }

    }

    private void HandleInternetOff()
    {
        if (internetPanel != null)
        {
            internetPanel.SetActive(true);
        }
        InternetOffEvent.Invoke();
        isApiData = true;
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
