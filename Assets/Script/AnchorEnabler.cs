using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnchorEnabler : MonoBehaviour
{
    public UnityEvent OnEnableEvent;
    private void OnEnable()
    {
        StartCoroutine(AnchorEnable());
    }

    public  IEnumerator AnchorEnable()
    {
        yield return new WaitForSeconds(2f);
        OnEnableEvent.Invoke();
    }
}
