using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayObjectEnable : MonoBehaviour
{
    public GameObject EnableObject;
    public GameObject EnableObject1;
    public GameObject EnableObject2ExtraTIme;
    public GameObject DisableObject;
    public GameObject DisableObject2ExtraTIme, DisableObject2ExtraTIme2;
    public bool EnableObject3ExtraTIme = false;

    public void GameObjectEnable()
    {
        StartCoroutine(DisEnaGameObject());
    }

    public IEnumerator DisEnaGameObject()
    {

        yield return new WaitForSeconds(3.6f);
        DisableObject2ExtraTIme.gameObject.SetActive(false);
        if (EnableObject3ExtraTIme)
        {
            DisableObject2ExtraTIme2.gameObject.SetActive(false);
        }
        EnableObject.gameObject.SetActive(true);
    
        EnableObject1.SetActive(true);

        yield return new WaitForSeconds(0.4f);
        DisableObject.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        EnableObject2ExtraTIme.gameObject.SetActive(true);



    }
}
