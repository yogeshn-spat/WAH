using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageAddManager : MonoBehaviour
{
    private LanguageManager languageManager;

    void Start()
    {
        languageManager = FindAnyObjectByType<LanguageManager>();
        // Assuming gameObjectManager is already assigned
        if(languageManager != null)
        {
            languageManager.AddGameObjectinUICardElement(gameObject);
        }

    }
}
