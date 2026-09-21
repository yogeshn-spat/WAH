using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class NEUR_AnchorManager : MonoBehaviour
{
    [Tooltip("Please add the Anchor prefab from Oculus or use your custom modified prefab")]
    public OVRSpatialAnchor anchorPrefab;    // Prefab for the spatial anchor
    [Tooltip("Please assign the Delete button")]
    public GameObject deleteButton;              // Button to delete anchor

    private OVRSpatialAnchor currentAnchor;  // Reference to the current anchor
    Action<OVRSpatialAnchor.UnboundAnchor, bool> _onLoadAnchor;
    [Tooltip("Please assign the transform for spawning the anchor here. This will determine the location and orientation of the anchor in your scene.")]
    public Transform anchorSpawnPos;
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
    [HideInInspector]
    public List<OVRSpatialAnchor> anchors = new List<OVRSpatialAnchor>();
    private OVRSpatialAnchor lastCreatedPrefab;
    public NEUR_AnchorLoader nEUR_AnchorLoader;

    public void CreateSpatialAnchor(bool fixPosition)
    {
        workingAnchor = Instantiate(anchorPrefab, anchorSpawnPos.position, anchorSpawnPos.rotation);
       // gameObject.GetComponent<BoxCollider>().enabled = true;
        fixPos = fixPosition;
        StartCoroutine(AnchorCreated(workingAnchor));
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
        PlayerPrefs.Save();
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
        anchors.Add(anchor);
        lastCreatedPrefab = anchor;

        SaveCreatedAnchor();
    }

    private void UnSaveAllAnchor()
    {
        foreach (var anchor in anchors)
        {
            unSaveAnchor(anchor);
        }
        anchors.Clear();
        SetNewAnchorAndClearOldAnchor();
    }

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

    public void SetNewAnchorAndClearOldAnchor()
    {
        anchors.Clear();
        if (PlayerPrefs.HasKey(numId))
        {
            int playerNumUuids = PlayerPrefs.GetInt(numId);
            for (int i = 0; i < playerNumUuids; i++)
            {
                PlayerPrefs.DeleteKey("uuid" + i);
                Destroy(GameObject.Find("DemoAnchorPrefabs(Clone)"));
            }
            PlayerPrefs.DeleteKey(numId);
            PlayerPrefs.Save();
            if (nEUR_AnchorLoader != null)
            {
                nEUR_AnchorLoader.AnchorDeleteOnClick();
            }

            _Environment.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void LoadSavedAnchor()
    {
        nEUR_AnchorLoader.LoadAnchorByUuid();
        fixPos = true;
    }
    public void GetAnchor()
    {
        workingAnchor = GameObject.Find("DemoAnchorPrefabs(Clone)").GetComponent<OVRSpatialAnchor>();

    }
}