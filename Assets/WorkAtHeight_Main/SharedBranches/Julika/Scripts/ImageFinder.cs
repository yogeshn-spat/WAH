using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFinder : MonoBehaviour
{
    // Start is called before the first frame update
    public void ImageFind9()
    {
        GameObject Platform = GameObject.Find("Scaffold PlatformImage");
        if (Platform != null)
        {
            Platform.SetActive(false);
        }
    }
    public void ImageFind1()
    {
        GameObject SafetyNet = GameObject.Find("SafetyNetImage");
        if (SafetyNet != null)
        {
            SafetyNet.SetActive(false);
        }

    }
    public void ImageFind2()
    {
        GameObject BasePlate = GameObject.Find("BasePlateImage");
        if (BasePlate != null)
        {
            BasePlate.SetActive(false);
        }

    }

    public void ImageFind3()
    {
        GameObject GuardRail = GameObject.Find("GuardRailImage");
        if (GuardRail != null)
        {
            GuardRail.SetActive(false);
        }

    }

    public void ImageFind4()
    {
        GameObject Plank = GameObject.Find("PlankImage");
        if (Plank != null)
        {
            Plank.SetActive(false);
        }

    }
    public void ImageFind5()
    {
        GameObject CementBag = GameObject.Find("CementBagImage");
        if (CementBag != null)
        {
            CementBag.SetActive(false);
        }

    }
    public void ImageFind6()
    {
        GameObject Rod = GameObject.Find("RodImage");
        if (Rod != null)
        {
            Rod.SetActive(false);
        }

    }
    public void ImageFind7()
    {
        GameObject LeaningCharacter = GameObject.Find("LeaningHumanImage");
        if (LeaningCharacter != null)
        {
            LeaningCharacter.SetActive(false);
        }

    }
    public void ImageFind8()
    {
        GameObject GuardRailTop = GameObject.Find("GuardRail(Floor-Level)Image");
        if (GuardRailTop != null)
        {
            GuardRailTop.SetActive(false);
        }

    }
}
