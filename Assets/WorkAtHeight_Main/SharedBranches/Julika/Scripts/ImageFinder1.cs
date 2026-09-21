using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFinder1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void ImageFind9()
    {
        GameObject Platform = GameObject.Find("Scaffold PlatformImages");
        if (Platform != null)
        {
            Platform.SetActive(false);
        }
    }
    public void ImageFind1()
    {
        GameObject SafetyNet = GameObject.Find("SafetyNetImages");
        if (SafetyNet != null)
        {
            SafetyNet.SetActive(false);
        }

    }
    public void ImageFind2()
    {
        GameObject BasePlate = GameObject.Find("BasePlateImages");
        if (BasePlate != null)
        {
            BasePlate.SetActive(false);
        }

    }

    public void ImageFind3()
    {
        GameObject GuardRail = GameObject.Find("GuardRailImages");
        if (GuardRail != null)
        {
            GuardRail.SetActive(false);
        }

    }

    public void ImageFind4()
    {
        GameObject Plank = GameObject.Find("PlankImages");
        if (Plank != null)
        {
            Plank.SetActive(false);
        }

    }
    public void ImageFind5()
    {
        GameObject CementBag = GameObject.Find("CementBagImages");
        if (CementBag != null)
        {
            CementBag.SetActive(false);
        }

    }
    public void ImageFind6()
    {
        GameObject Rod = GameObject.Find("RodImages");
        if (Rod != null)
        {
            Rod.SetActive(false);
        }

    }
    public void ImageFind7()
    {
        GameObject LeaningCharacter = GameObject.Find("LeaningHumanImages");
        if (LeaningCharacter != null)
        {
            LeaningCharacter.SetActive(false);
        }

    }
    public void ImageFind8()
    {
        GameObject GuardRailTop = GameObject.Find("GuardRail(Floor-Level)Images");
        if (GuardRailTop != null)
        {
            GuardRailTop.SetActive(false);
        }

    }
}
