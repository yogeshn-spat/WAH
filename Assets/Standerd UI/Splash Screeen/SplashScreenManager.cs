using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    [Header("Logos Settings")]
    public List<NEUR_SplashScreen> logos;  // List of sprites and durations for logos
    public Image logoImage;  // Reference to the UI Image component where logos will be displayed

    [Header("Next Scene")]
    public int MainScene;

    [Header("Effects Settings")]
    [Range(0f, 5f)] public float fadeDuration = 1f;  // Duration for fade in/out
    [Range(0f, 5f)] public float zoomDuration = 1f;  // Duration for zoom effect

    private void Start()
    {
        // Start showing logos sequentially
        StartCoroutine(ShowLogosSequentially());
    }

    private IEnumerator ShowLogosSequentially()
    {
        for (int i = 0; i < logos.Count; i++)
        {
            // Assign the current sprite to the Image component
            logoImage.sprite = logos[i].logoSprite;
            logoImage.SetNativeSize();
            logoImage.transform.localScale = Vector3.zero;  // Start at scale 0

            // Show the logo with zoom and fade in
            yield return StartCoroutine(ZoomAndFadeIn(logoImage, logos[i].zoomScale));

            // Wait for the specified duration to display the logo
            yield return new WaitForSeconds(logos[i].logoDuration);

            // Hide the logo with zoom and fade out
            yield return StartCoroutine(ZoomAndFadeOut(logoImage));
        }

        // After showing all logos, load the main scene
        yield return new WaitForSeconds(zoomDuration);
        SceneManager.LoadScene(MainScene);  // Load the main scene
    }

    private IEnumerator ZoomAndFadeIn(Image logo, float targetScale)
    {
        float timer = 0f;
        Vector3 originalScale = Vector3.zero;  // Start at 0 scale
        Vector3 finalScale = new Vector3(targetScale, targetScale, targetScale);

        Color color = logo.color;
        color.a = 0;
        logo.color = color;
        logo.gameObject.SetActive(true);

        while (timer < zoomDuration)
        {
            timer += Time.deltaTime;

            // Zoom effect from scale 0 to target scale
            logo.transform.localScale = Vector3.Lerp(originalScale, finalScale, timer / zoomDuration);

            // Fade effect
            color.a = Mathf.Lerp(0, 1, timer / fadeDuration);
            logo.color = color;

            yield return null;
        }
    }

    private IEnumerator ZoomAndFadeOut(Image logo)
    {
        float timer = 0f;
        Vector3 originalScale = logo.transform.localScale;
        Vector3 finalScale = Vector3.zero;  // End at scale 0

        Color color = logo.color;

        while (timer < zoomDuration)
        {
            timer += Time.deltaTime;

            // Zoom out effect from current scale to 0
            logo.transform.localScale = Vector3.Lerp(originalScale, finalScale, timer / zoomDuration);

            // Fade out effect
            color.a = Mathf.Lerp(1, 0, timer / fadeDuration);
            logo.color = color;

            yield return null;
        }

        logo.gameObject.SetActive(false);
    }
}

[System.Serializable]
public class NEUR_SplashScreen
{
    public Sprite logoSprite;  // The logo sprite to display
    [Range(0f, 5f)] public float logoDuration = 2f;
    [Range(0f, 5f)] public float zoomScale = 0.5f;  // Zoom amount for the logo
}
