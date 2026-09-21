
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AnchorLoader : MonoBehaviour
{
    [HideInInspector]
    public OVRSpatialAnchor anchorPrefab;
    [HideInInspector]
    public SpatialAnchorManager spatialAnchorManager;

    //public GameObject CreateAnchorBtn;
    public GameObject DeleteAnchorBtn;
    //public GameObject anchorBtnParent;
    public int isAnchorDelete;
    Action<OVRSpatialAnchor.UnboundAnchor, bool> _onLoadAnchor;

    [SerializeField]
    public int playerUuidCount;
    //public GameObject DebugText;
    private void Awake()
    {
        spatialAnchorManager = GetComponent<SpatialAnchorManager>();
        anchorPrefab = spatialAnchorManager.anchorPrefab;
        _onLoadAnchor = OnLocalized;

    }

    public void Start()
    {
        int myValue = PlayerPrefs.GetInt("AnchorDelete", 0);
        playerUuidCount = PlayerPrefs.GetInt(SpatialAnchorManager.numId);

        if (playerUuidCount >= 1)
        {
            LoadAnchorByUuid();
            DeleteAnchorBtn.SetActive(true);
            spatialAnchorManager.fixPos = true;
            spatialAnchorManager.gameObject.GetComponent<BoxCollider>().enabled = true;

            //DebugText.SetActive(true);
        }

        else if (playerUuidCount < 1)
        {
            DeleteAnchorBtn.SetActive(false);
        }

    }
    public void LoadAnchorByUuid()
    {
        if (!PlayerPrefs.HasKey(SpatialAnchorManager.numId))
        {
            PlayerPrefs.SetInt(SpatialAnchorManager.numId, 0);
        }

        var playerUuidCount = PlayerPrefs.GetInt(SpatialAnchorManager.numId);

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
        spatialAnchorManager.gameObject.GetComponent<BoxCollider>().enabled = true;
        //DebugText.SetActive(true);
        spatialAnchorManager.GetAnchor();
        unboundAnchor.BindTo(spatialAnchor);

        if (spatialAnchor.TryGetComponent<OVRSpatialAnchor>(out var anchor))
        {
            var uuidText = spatialAnchor.GetComponentInChildren<TextMeshProUGUI>();
            var savedStatusText = spatialAnchor.GetComponentInChildren<TextMeshProUGUI>();

            //uuidText.text = "UUID : " + spatialAnchor.Uuid.ToString();
            //savedStatusText.text = "Loaded from Device";
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