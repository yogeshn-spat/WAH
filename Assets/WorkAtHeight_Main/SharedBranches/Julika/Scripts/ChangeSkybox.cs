using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    public Material SkyBoxChangeMaterial;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSkyboxx()
    {
        RenderSettings.skybox = SkyBoxChangeMaterial;
    }
}