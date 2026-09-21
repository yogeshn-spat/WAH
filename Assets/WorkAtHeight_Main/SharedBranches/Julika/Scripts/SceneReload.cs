using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
    int sceneNumber = 0;

    public void SceneReloader()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(LoadSceneReloader());

    }
    public void SceneReloaderNext()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadSceneReloaderNext());
    }

    public void SceneReloaderPre()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        //AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        StartCoroutine(LoadSceneReloaderPre());
    }

    public void SceneReloaderMenu()
    {
        StartCoroutine(LoadSceneReloaderMenu());
    }

    public void SceneReloaderLearning()
    {
        //SceneManager.LoadScene(sceneNumber+2);
        StartCoroutine(LoadSceneReloaderMenu());
    }

    public void QuitEnable()
    {
        Time.timeScale = 0;
    }

    IEnumerator LoadSceneReloaderMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNumber);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadSceneReloaderLearning()

    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNumber);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadSceneReloaderPre()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadSceneReloaderNext()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadSceneReloader()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
