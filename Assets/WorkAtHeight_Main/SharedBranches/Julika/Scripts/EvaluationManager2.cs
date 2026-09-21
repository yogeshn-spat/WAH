using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationManager2 : MonoBehaviour
{
    public List<GameObject> correctObjects;
    public List<GameObject> wrongObjects;


    public void BtnEvaluation2()
    {

        if (correctObjects.Count < 3 || wrongObjects.Count < 1)
        {
            //Debug.LogError("Not enough objects in the lists to perform the operation.");
            return;
        }

        List<int> randomIndices = new List<int>();
        while (randomIndices.Count < 3)
        {
            int randomIndex = Random.Range(0, correctObjects.Count);
            if (!randomIndices.Contains(randomIndex))
            {
                randomIndices.Add(randomIndex);
                correctObjects[randomIndex].SetActive(true);
            }
        }

        List<int> nonRandomIndices = new List<int>();
        for (int i = 0; i < correctObjects.Count; i++)
        {
            if (!randomIndices.Contains(i))
            {
                nonRandomIndices.Add(i);
            }
        }

        foreach (int nonRandomIndex in nonRandomIndices)
        {
            if (nonRandomIndex < wrongObjects.Count)
            {
                wrongObjects[nonRandomIndex].SetActive(true);
            }
            else
            {
                //Debug.LogError("Not enough wrong objects to match the non-random correct objects.");
            }
        }
    }
}
