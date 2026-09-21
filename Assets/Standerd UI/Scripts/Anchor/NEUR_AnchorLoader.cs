using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NEUR_AnchorLoader : MonoBehaviour
{
    [HideInInspector]
    public OVRSpatialAnchor anchorPrefab;
    [HideInInspector]
    public NEUR_AnchorManager spatialAnchorManager;
    public int isAnchorDelete;
    Action<OVRSpatialAnchor.UnboundAnchor, bool> _onLoadAnchor;
    public GameObject DeleteButton;
    public NEUR_EnvironmentAnchor anchorManager;
    private void Awake()
    {
        spatialAnchorManager = GetComponent<NEUR_AnchorManager>();
        anchorPrefab = spatialAnchorManager.anchorPrefab;
        _onLoadAnchor = OnLocalized;

    }

    public void Start()
    {
        InitilizeButton();

    }

    public void InitilizeButton()
    {
        int myValue = PlayerPrefs.GetInt("AnchorDelete", 0);
        var playerUuidCount = PlayerPrefs.GetInt(NEUR_AnchorManager.numId);

        if (playerUuidCount != 0)
        {
            LoadAnchorByUuid();
            spatialAnchorManager.fixPos = true;
            DeleteButton.SetActive(true);
        }
        else
        {
            DeleteButton.SetActive(false);

        }
    }

    public void LoadAnchorByUuid()
    {
        if (!PlayerPrefs.HasKey(NEUR_AnchorManager.numId))
        {
            PlayerPrefs.SetInt(NEUR_AnchorManager.numId, 0);
        }

        var playerUuidCount = PlayerPrefs.GetInt(NEUR_AnchorManager.numId);

        if (playerUuidCount == 0)
        {

            return;
        }


        var uuids = new Guid[playerUuidCount];
        for (int i = 0; i < playerUuidCount; ++i)
        {
            var uuidKey = "uuid" + i;
            var currentUuid = PlayerPrefs.GetString(uuidKey);

            uuids[i] = new Guid(currentUuid);
        }

        Load(new OVRSpatialAnchor.LoadOptions
        {
            Timeout = 0,
            StorageLocation = OVRSpace.StorageLocation.Local,
            Uuids = uuids
        });
    }

    private void Load(OVRSpatialAnchor.LoadOptions options)
    {
        OVRSpatialAnchor.LoadUnboundAnchors(options, anchors =>
        {
            if (anchors == null)
            {
                return;
            }

            foreach (var anchor in anchors)
            {
                if (anchor.Localized)
                {
                    _onLoadAnchor(anchor, true);

                }
                else if (!anchor.Localizing)
                {
                    anchor.Localize(_onLoadAnchor);
                }
            }
        });
    }

    private void OnLocalized(OVRSpatialAnchor.UnboundAnchor unboundAnchor, bool success)
    {
        if (!success) return;

        var pose = unboundAnchor.Pose;
        var spatialAnchor = Instantiate(anchorPrefab, pose.position, pose.rotation);
        spatialAnchorManager.fixPos = true;
        spatialAnchorManager.GetAnchor();
        spatialAnchor.gameObject.SetActive(true);
        anchorManager.gameObject.SetActive(true);           
        anchorManager.GetAnchor();

        unboundAnchor.BindTo(spatialAnchor);

        if (spatialAnchor.TryGetComponent<OVRSpatialAnchor>(out var anchor))
        {
            var uuidText = spatialAnchor.GetComponentInChildren<TextMeshProUGUI>();
            var savedStatusText = spatialAnchor.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void AnchorDeleteOnClick()
    {
        PlayerPrefs.SetInt("AnchorDelete", 1);
        PlayerPrefs.Save();
    }

    public void AnchorDeleteDisableOnClick()
    {
        PlayerPrefs.SetInt("AnchorDelete", 0);
        PlayerPrefs.Save();
    }
}
