using System.Collections;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    private Material _material;
    private bool _isFadingOut = true;

    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public void Fade(bool fadeOut,float value)
    {
        if (fadeOut && _isFadingOut)
            return;
        if (!fadeOut && !_isFadingOut)
            return;
        _isFadingOut = fadeOut;
        StopAllCoroutines();
        string val = _isFadingOut ? "OUT" : "in";
        Debug.Log($"Starting fade {val} coroutine");
        StartCoroutine(PlayEffect(fadeOut,value));
    }

    private IEnumerator PlayEffect(bool fadeOut, float value)
    {
        float startAlpha = _material.GetFloat("_Alpha");
        float endAlpha = fadeOut ? 1.0f : 0.0f;
        float remainingTime
            = value * Mathf.Abs(endAlpha - startAlpha);

        float elapsedTime = 0;
        while (elapsedTime < value)
        {
            elapsedTime += Time.deltaTime;
            float tempVal = Mathf.Lerp(startAlpha, endAlpha,
                elapsedTime / remainingTime);

            _material.SetFloat("_Alpha", tempVal);
            yield return null;
        }
        _material.SetFloat("_Alpha", endAlpha);
    }
    public void Fadein()
    {
       Fade(true, 1f);
    }
    public void Fadeout()
    {
        Fade(false, 1);
    }
}
