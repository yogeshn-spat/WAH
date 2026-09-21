using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField]
    private Transform Controlpoints;

    private Vector3 Gizmozpoints;

    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.5f)
        {
            //Gizmozpoints = Mathf.Pow(1 - t, 3) * Controlpoints[0].position+ 3* Mathf.Pow(1 - t, 2) * t * Controlpoints[1].position + 3 * (1 - t) * Mathf.Pow(t, 2) * Controlpoints[2].position
        }
    }
}
