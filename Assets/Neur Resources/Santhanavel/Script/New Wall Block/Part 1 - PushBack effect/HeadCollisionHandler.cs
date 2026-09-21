using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private HeadCollisionDetector _detector;
    [SerializeField]
    public float pushBackStrength = 1.0f;
    [SerializeField]
    OVRCameraRig CameraRig;
    [SerializeField]
    private FadeEffect _blackScreenFade;
    [SerializeField, Range(0, 0.5f)]
    private float _detectionDelay = 0.05f;
    private float _currentTime = 0;
    public float delayFadein = 0.025f;
    public float delayFadeOut = 1.0f;
    public bool canFade = true;
  
    private Vector3 CalculatePushBackDirection(List<RaycastHit> colliderHits)
    {

        Vector3 combinedNormal = Vector3.zero;
        foreach (RaycastHit hitPoint in colliderHits)
        {
            combinedNormal +=
                new Vector3(hitPoint.normal.x, 0, hitPoint.normal.z);
        }
        return combinedNormal;
    }

    private void Update()
    {
        if (_detector.DetectedColliderHits.Count > 0)
        {
            if (canFade)
            {
                _blackScreenFade.Fade(true, delayFadein);
            }
            Vector3 pushBackDirection = CalculatePushBackDirection(_detector.DetectedColliderHits);
            Debug.DrawRay(transform.position, pushBackDirection.normalized, Color.magenta);
            CameraRig.gameObject.transform.position = CameraRig.transform.position + (pushBackDirection.normalized * pushBackStrength * Time.deltaTime);

            return;
        }
        if (_detector.DetectedColliderHits.Count <= 0 )
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _detectionDelay)
            {
                _currentTime = 0;
                if (canFade)
                {
                    _blackScreenFade.Fade(false, delayFadeOut);
                }
            }

            return;
        }

    }
}
