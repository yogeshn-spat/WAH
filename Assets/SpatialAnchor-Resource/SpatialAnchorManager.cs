using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SpatialAnchorManager : MonoBehaviour
{
    //public Transform rigParent;
    //public Transform rigTarget;
    public OVRSpatialAnchor anchorPrefab;
    public Transform _AnchorSpawnPos;
    public Transform _Environment;
    //[HideInInspector]
    public bool fixPos = false;
    [HideInInspector]
    public Canvas canvas;
    public const string numId = "numUuids";
    [HideInInspector]
    public TextMeshProUGUI uuidText;
    [HideInInspector]
    public TextMeshProUGUI savedStatusText;
    //[HideInInspector]
    public OVRSpatialAnchor workingAnchor;
    //[HideInInspector]
    public List<OVRSpatialAnchor> anchors = new List<OVRSpatialAnchor>();
    private OVRSpatialAnchor lastCreatedPrefab;
    public AnchorLoader SpatialAnchorLoader;



    private void Start()
    {

    }
    public void CreateSpatialAnchor(string _AnchorName)
    {
        
        if (_AnchorName == "PPE")
        {
            workingAnchor = Instantiate(anchorPrefab, _AnchorSpawnPos.position, _AnchorSpawnPos.rotation);
            workingAnchor.name = _AnchorName;
            //environmentStartPosition = _Environment;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            anchors.Add(workingAnchor);
            //canvas = workingAnchor.gameObject.GetComponentInChildren<Canvas>();
            //uuidText = canvas.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            //savedStatusText = canvas.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            fixPos = true;
            StartCoroutine(AnchorCreated(workingAnchor));
        }
        else if (GameObject.Find("PPE") != null)
        {
            workingAnchor = Instantiate(anchorPrefab, _AnchorSpawnPos.position, _AnchorSpawnPos.rotation);
            workingAnchor.name = _AnchorName;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            anchors.Add(workingAnchor);
            fixPos = true;
        }

    }



    public void SavePpeAnchorData()
    {
        if (SpatialAnchorLoader.playerUuidCount >= 1)
        {
            StartCoroutine(AnchorCreated(workingAnchor));
            GameObject _PPEAnchor = GameObject.Find("PPE");
            GameObject _DemoPrefab = GameObject.Find("DemoAnchorPrefabs(Clone)");
            if (_PPEAnchor != null)
            {
                workingAnchor = _PPEAnchor.GetComponent<OVRSpatialAnchor>();

            }
            else if (_DemoPrefab != null)
            {
                workingAnchor = _DemoPrefab.GetComponent<OVRSpatialAnchor>();
                workingAnchor.name = "PPE";

            }
        }

    }
    public void SaveCreatedAnchor()
    {
        lastCreatedPrefab.Save((lastCreatedPrefab, success) =>
        {
            if (success)
            {
                //savedStatusText.text = "saved";
            }
        });

        SaveUuidToPlayerPrefs(lastCreatedPrefab.Uuid);
    }

    void SaveUuidToPlayerPrefs(Guid uuid)
    {
        if (!PlayerPrefs.HasKey(numId))
        {
            PlayerPrefs.SetInt(numId, 0);
        }

        int playerNumUuids = PlayerPrefs.GetInt(numId);
        PlayerPrefs.SetString("uuid" + playerNumUuids, uuid.ToString());
        PlayerPrefs.SetInt(numId, ++playerNumUuids);
    }

    public void UnSaveCreatedAnchor()
    {
        lastCreatedPrefab.Erase((lastCreatedPrefab, success) =>
        {
            if (success)
            {
                savedStatusText.text = "Not saved";
            }
        });

        SaveUuidToPlayerPrefs(lastCreatedPrefab.Uuid);
    }


    private IEnumerator AnchorCreated(OVRSpatialAnchor anchor)
    {
        while (!anchor.Created && !anchor.Localized)
        {
            yield return new WaitForEndOfFrame();
        }

        Guid anchorGuid = anchor.Uuid;
        //anchors.Add(anchor);
        lastCreatedPrefab = anchor;

        //uuidText.text = anchorGuid.ToString();
        //savedStatusText.text = "Not Saved";
        SaveCreatedAnchor();
    }

    //private void UnSaveAllAnchor()
    //{
    //    foreach (var anchor in anchors)
    //    {
    //        unSaveAnchor(anchor);
    //    }
    //    anchors.Clear();
    //    SetNewAnchorAndClearOldAnchor();
    //}

    private void unSaveAnchor(OVRSpatialAnchor anchor)
    {
        anchor.Erase((erasedAnchor, success) =>
        {
            if (success)
            {
                var textComponents = erasedAnchor.GetComponentInChildren<TextMeshProUGUI>();

            }
        });
    }

    public void SetNewAnchorAndClearOldAnchor(string _AnchorName)
    {

        if (PlayerPrefs.HasKey(numId))
        {
            int playerNumUuids = PlayerPrefs.GetInt(numId);
            for (int i = 0; i < playerNumUuids; i++)
            {
                PlayerPrefs.DeleteKey("uuid" + i);
                Destroy(GameObject.Find(_AnchorName));
            }
            PlayerPrefs.DeleteKey(numId);
            PlayerPrefs.Save();
        }
        anchors.Clear();
        if (SpatialAnchorLoader != null)
        {
            SpatialAnchorLoader.AnchorDeleteOnClick();
        }
        
        _Environment.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void DeleteAnchorwithoutId()
    {
        if(anchors!=null) 
        { 
            for (int i = 0; i < anchors.Count; i++)
            {
                PlayerPrefs.DeleteKey("uuid" + i);
                Destroy(anchors[i].gameObject);
            }
            PlayerPrefs.DeleteKey(numId);
            PlayerPrefs.Save();
        }
        anchors.Clear();
        if (SpatialAnchorLoader != null)
        {
            SpatialAnchorLoader.AnchorDeleteOnClick();
        }
        if (GameObject.Find("PPE") != null)
        {
            GameObject anchorPPE = GameObject.Find("PPE");
            Destroy(anchorPPE);
        }
        _Environment.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void DeleteTempAnchor(string _AnchorName)
    {
        OVRSpatialAnchor objectToRemove = anchors.Find(obj => obj.name == _AnchorName);

        if (objectToRemove != null)
        {
            // Remove it from the anchors list
            anchors.Remove(objectToRemove);

            // Destroy the GameObject
            Destroy(objectToRemove.gameObject);
        }
        _Environment.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void LoadSavedAnchor()
    {
        SpatialAnchorLoader.LoadAnchorByUuid();
        gameObject.GetComponent<BoxCollider>().enabled = true;
        fixPos = true;
    }

    private void OnTriggerStay(Collider other)
    {

        if (workingAnchor != null && other.gameObject.GetComponent<HeadCollisionDetector>() != null)
        {

            if (workingAnchor != null && fixPos)
            {
                _Environment.position = workingAnchor.transform.position;
                Vector3 rotation = _Environment.rotation.eulerAngles;
                rotation.y = workingAnchor.transform.rotation.eulerAngles.y;
                _Environment.rotation = Quaternion.Euler(rotation);
            }
        }

    }

    public void GetAnchor()
    {
        SavePpeAnchorData();
    }

    public void AnchorSetFalse()
    {
        if (workingAnchor != null)
        {
            GameObject.Find("PPE").GetComponent<OVRSpatialAnchor>().enabled = false;
        }

    }

    public void AnchorSetTrue()
    {
        if(workingAnchor == null)
        { 
            workingAnchor = GameObject.Find("PPE").GetComponent<OVRSpatialAnchor>();
            if (workingAnchor != null)
            {
                GameObject.Find("PPE").GetComponent<OVRSpatialAnchor>().enabled = true;
                fixPos = true;
            }
        }
       

    }
}

