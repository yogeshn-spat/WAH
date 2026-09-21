using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NEUR_SceneHandler : MonoBehaviour
{
    public NEUR_SceneName CurrentScene = NEUR_SceneName.learning;

    public FadeEffect fadeEffect;
    public HeadCollisionHandler collisionHandler;// Assign the FadeEffect script in the inspector
    public GameObject WarningPanel;
    private float fadeDuration = 0.25f;
    private float sceneDuration = 2.5f;
    public static NEUR_SceneHandler instance;

    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    public void GoToMainScene()
    {
        ChangeScene(0);
    }
    public void GoToLearningScene()
    {
        ChangeScene(1);
    }
    public void GoToEvaluationScene()
    {
        ChangeScene(2);
    }


    public void ChangeScene(int sceneIndex)
    {
        StartCoroutine(ChangeSceneRoutine(sceneIndex));
    }

    private IEnumerator ChangeSceneRoutine(int sceneIndex)
    {
        // Fade out
        collisionHandler.canFade = false;
        fadeEffect.Fade(true, fadeDuration);
        WarningPanel.SetActive(true);
        yield return new WaitForSeconds(sceneDuration);

        // Load the new scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        // Fade in
        fadeEffect.Fade(false, fadeDuration);
        WarningPanel.SetActive(false);

    }
}
public enum NEUR_SceneName
{
    onboarding,
    learning,
    evaluation
}