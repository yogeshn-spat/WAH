//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void Start()
    {
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}