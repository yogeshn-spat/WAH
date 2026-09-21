using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextViewerController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Button nextButton;

    private string[] steps = { "Step 1", "Step 2", "Step 3" };
    private int currentStep = 0;

    void Start()
    {
        DisplayCurrentStep();

        nextButton.onClick.AddListener(NextButtonClick);
    }

    void DisplayCurrentStep()
    {
        textMeshPro.text = steps[currentStep];
    }

    void NextButtonClick()
    {
        currentStep = (currentStep + 1) % steps.Length;
        DisplayCurrentStep();
    }
}
