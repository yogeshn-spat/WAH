using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationManager1 : MonoBehaviour
{
    public List<GameObject> correctObjects; 
    public List<GameObject> wrongObjects;

    public void BtnEvaluation()
    {
        if (correctObjects.Count < 3 || wrongObjects.Count < 1)
        {
            //Debug.LogError("Not enough objects in the lists to perform the operation.");
            return;
        }

        int randomIndex1 = Random.Range(0, correctObjects.Count);
        int randomIndex2;

        do
        {
            randomIndex2 = Random.Range(0, correctObjects.Count);
        } while (randomIndex2 == randomIndex1);

        correctObjects[randomIndex1].SetActive(true);
        correctObjects[randomIndex2].SetActive(true);

        int nonRandomIndex = 0;
        while (nonRandomIndex == randomIndex1 || nonRandomIndex == randomIndex2)
        {
            nonRandomIndex++;
        }

        if (nonRandomIndex < wrongObjects.Count)
        {
            wrongObjects[nonRandomIndex].SetActive(true);
        }
        else
        {
            //Debug.LogError("Not enough wrong objects to match the non-random correct object.");
        }
    }
}
