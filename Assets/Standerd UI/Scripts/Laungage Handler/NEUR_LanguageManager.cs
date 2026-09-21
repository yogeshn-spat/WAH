using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NEUR_LanguageManager : MonoBehaviour
{
    [SerializeField] private LanguageType currentLanguage;
    [SerializeField] private TMP_FontAsset tamilFont;
    [SerializeField] private TMP_FontAsset englishFont;
    [SerializeField] private TMP_FontAsset hindiFont;

    // Observer pattern using delegate
    public delegate void LanguageChanged(LanguageType newLanguage, TMP_FontAsset newFont);
    private event LanguageChanged onLanguageChanged;

    public LanguageType CurrentLanguage => currentLanguage;

    private void Awake()
    {
        DontDestroyOnLoad(this);
      //  LoadSavedLanguage();
        ChangeLanguage(currentLanguage);
    }

    private void LoadSavedLanguage()
    {
        string savedLanguage = PlayerPrefs.GetString(NEUR_Constant.NEUR_LanguageSelected, NEUR_Constant.NEUR_English);

        switch (savedLanguage)
        {
            case NEUR_Constant.NEUR_Tamil:
                ChangeToTamil();
                break;
            case NEUR_Constant.NEUR_Hindi:
                ChangeToHindi();
                break;
            default:
                ChangeToEnglish();
                break;
        }
    }

    public void RegisterObserver(System.Action<LanguageType, TMP_FontAsset> observer)
    {
        onLanguageChanged += new LanguageChanged(observer);
    }

    public void UnregisterObserver(System.Action<LanguageType, TMP_FontAsset> observer)
    {
        onLanguageChanged -= new LanguageChanged(observer);
    }

    public void ChangeLanguage(LanguageType newLanguage)
    {
        if (currentLanguage != newLanguage)
        {
            currentLanguage = newLanguage;
            NotifyObservers();
        }
    }

    private void NotifyObservers()
    {
        onLanguageChanged?.Invoke(currentLanguage, GetCurrentFont());
    }

    public TMP_FontAsset GetCurrentFont()
    {
        return currentLanguage switch
        {
            LanguageType.Tamil => tamilFont,
            LanguageType.English => englishFont,
            LanguageType.Hindi => hindiFont,
            _ => englishFont,
        };
    }

    public void ChangeToTamil()
    {
        ChangeLanguage(LanguageType.Tamil);
        PlayerPrefs.SetString(NEUR_Constant.NEUR_LanguageSelected, NEUR_Constant.NEUR_Tamil);
        PlayerPrefs.Save();
    }

    public void ChangeToHindi()
    {
        ChangeLanguage(LanguageType.Hindi);
        PlayerPrefs.SetString(NEUR_Constant.NEUR_LanguageSelected, NEUR_Constant.NEUR_Hindi);
        PlayerPrefs.Save();
    }

    public void ChangeToEnglish()
    {
        ChangeLanguage(LanguageType.English);
        PlayerPrefs.SetString(NEUR_Constant.NEUR_LanguageSelected, NEUR_Constant.NEUR_English);
        PlayerPrefs.Save();
    }
}

// Enum to represent language types
public enum LanguageType
{
    Tamil,
    English,
    Hindi
}
