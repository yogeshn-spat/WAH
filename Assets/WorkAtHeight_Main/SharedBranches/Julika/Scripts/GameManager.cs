using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance;

    public GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
    //public GameObject Menu;
    //public GameObject OnBoarding;
    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}


    public void Update()
    {
    }

    public void Btn()
    {
        //OnBoarding = GameObject.Find("OnBoarding");
        //Menu = GameObject.Find("Menu");
        //if (Menu != null && !Menu.activeSelf)
        //{
        //    Instance.Menu.SetActive(false);
        //}
        //if (OnBoarding != null && !OnBoarding.activeSelf)
        //{
        //    Instance.OnBoarding.SetActive(false);
        //}

        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Menu" && !obj.activeSelf)
            {
                obj.SetActive(false);
            }
        }



    }
}