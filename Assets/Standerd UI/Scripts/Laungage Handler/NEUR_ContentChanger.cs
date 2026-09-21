using HindiFontReplacer;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NEUR_ContentChanger : MonoBehaviour
{
    [Header("Text Content Configuration")]
    public NEUR_TextContent content; // ScriptableObject holding text for different languages

    [Header("Language Manager")]
     private NEUR_LanguageManager languageManager; // Manager handling language switching

    [Range(-10, 10)]
    public int TamilFontSpace = 1, HindFontSpace = -2, EnglishFontSpace = 0;
    private TMP_Text textComponent; // TextMeshPro component to update

    private LanguageType currentLanguage; // Currently active language
    private TMP_FontAsset currentFont; // Currently active font

    // Dictionary for language-based character spacing
    private Dictionary<LanguageType, float> characterSpacingByLanguage;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();

        if (languageManager == null)
        {
            languageManager = FindObjectOfType<NEUR_LanguageManager>();
        }

        InitializeCharacterSpacing(); // Setup spacing for different languages
    }

    private void OnEnable()
    {
        languageManager.RegisterObserver(UpdateContent);
        UpdateContent(languageManager.CurrentLanguage, languageManager.GetCurrentFont());
    }

    private void OnDisable()
    {
        languageManager.UnregisterObserver(UpdateContent);
    }

    /// <summary>
    /// Initialize default character spacing for each language.
    /// </summary>
    private void InitializeCharacterSpacing()
    {
        characterSpacingByLanguage = new Dictionary<LanguageType, float>
        {
            { LanguageType.English, EnglishFontSpace },
            { LanguageType.Tamil, TamilFontSpace },  // Example spacing for Tamil
            { LanguageType.Hindi, HindFontSpace }  // Example spacing for Hindi
        };
    }

    /// <summary>
    /// Updates the text content and settings based on the new language and font.
    /// </summary>
    public void UpdateContent(LanguageType newLanguage, TMP_FontAsset newFont)
    {
        if (newLanguage != currentLanguage || newFont != currentFont)
        {
            currentLanguage = newLanguage;
            currentFont = newFont;

            UpdateTextContent();
            UpdateFont();
            UpdateCharacterSpacing();
            ManageLanguageSpecificComponents();
        }
    }

    /// <summary>
    /// Update the displayed text based on the current language.
    /// </summary>
    private void UpdateTextContent()
    {
        if (content == null) return;

        textComponent.text = currentLanguage switch
        {
            LanguageType.Tamil => content.tamilContent,
            LanguageType.Hindi => content.hindiContent,
            _ => content.englishContent
        };
    }

    /// <summary>
    /// Update the font based on the current language.
    /// </summary>
    private void UpdateFont()
    {
        textComponent.font = currentFont;
    }

    /// <summary>
    /// Update character spacing based on the current language.
    /// </summary>
    private void UpdateCharacterSpacing()
    {
        if (characterSpacingByLanguage.TryGetValue(currentLanguage, out float spacing))
        {
            textComponent.characterSpacing = spacing;
        }
    }

    /// <summary>
    /// Manage adding and removing language-specific components.
    /// </summary>
    private void ManageLanguageSpecificComponents()
    {
        // Remove both components initially if they exist
        RemoveLanguageSpecificComponents();

        // Conditionally add the required component based on the current language
        if (currentLanguage == LanguageType.Tamil)
        {
            if (gameObject.GetComponent<CharReplacerTamil>() == null)
            {
                gameObject.AddComponent<CharReplacerTamil>();
            }
        }
        else if (currentLanguage == LanguageType.Hindi)
        {
            if (gameObject.GetComponent<CharReplacerHindi>() == null)
            {
                gameObject.AddComponent<CharReplacerHindi>();
            }
        }
    }

    /// <summary>
    /// Removes both CharReplacer components if they exist.
    /// </summary>
    private void RemoveLanguageSpecificComponents()
    {
        var hindiReplacer = gameObject.GetComponent<CharReplacerHindi>();
        if (hindiReplacer != null)
        {
            Destroy(hindiReplacer);
        }

        var tamilReplacer = gameObject.GetComponent<CharReplacerTamil>();
        if (tamilReplacer != null)
        {
            Destroy(tamilReplacer);
        }
    }
}
