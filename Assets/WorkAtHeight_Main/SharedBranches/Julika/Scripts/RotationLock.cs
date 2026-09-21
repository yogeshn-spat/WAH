using UnityEngine;

public class RotationLock : MonoBehaviour
{
    public bool lockX;
    public bool lockY;
    public bool lockZ;
    public bool useLocalRotation = false;

    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void LateUpdate()
    {
        Vector3 eulerAngles = useLocalRotation ? transform.localEulerAngles : transform.eulerAngles;
        eulerAngles.x = lockX ? originalRotation.eulerAngles.x : eulerAngles.x;
        eulerAngles.y = lockY ? originalRotation.eulerAngles.y : eulerAngles.y;
        eulerAngles.z = lockZ ? originalRotation.eulerAngles.z : eulerAngles.z;

        if (useLocalRotation)
        {
            transform.localEulerAngles = eulerAngles;
        }
        else
        {
            transform.eulerAngles = eulerAngles;
        }
    }
}