using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrefabGameobjectAssign : MonoBehaviour
{

    public GameObject HandRay_Left;
    public GameObject HandaRay_Right;

    public UnityEvent GetEvent;

    // Start is called before the first frame update
    void Start()
    {
        GetPrefab();
    }
    public void GetPrefab()
    {
        HandaRay_Right = GameObject.Find("HandRayInteractor_R");
        HandRay_Left = GameObject.Find("HandRayInteractor_L");

    }
    public void PrefabEvent()
    {
        HandaRay_Right.SetActive(true);
        HandRay_Left.SetActive(true);
    }
}
