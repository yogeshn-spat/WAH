using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGameObject : MonoBehaviour
{
    public GameObject New_OnBoarding;
    public GameObject Current_OnBoarding;
    public GameObject Parent;
    public Quaternion rotation;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        Current_OnBoarding = GameObject.Find("OnBoarding-GO");
        Parent = GameObject.Find("-----------Scenes-----------");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameObjectInstantiation()
    {
        Destroy(Current_OnBoarding);
        //Instantiate(New_OnBoarding);
        (Instantiate(New_OnBoarding, position, rotation) as GameObject).transform.parent = Parent.transform;
    }
}
