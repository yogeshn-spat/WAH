using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTargetProvider : MonoBehaviour
{
    [SerializeField]
    private DirectionalArrow arrow;

    private void OnEnable()
    {
        changetarget(this.transform);
    }
    private void changetarget(Transform target)
    {
        arrow.SetTarget(target);

    }
}
