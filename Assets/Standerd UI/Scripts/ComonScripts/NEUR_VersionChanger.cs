using TMPro;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class NEUR_VersionChanger : MonoBehaviour
{
    public string newVersion = "V0.1.2";  // Default version number
    public string productName = "Emergency Response-CPR Simulator";  // Default product name
    public string packageName = "com.DefaultCompany.EmergencyResponseCPR";  // Default package name
    public TMP_Text versionText;

    public void ChangeVersionNumber()
    {
#if UNITY_EDITOR
        // Update PlayerSettings with the new values in the editor
        PlayerSettings.bundleVersion = newVersion;
        PlayerSettings.productName = productName;
        PlayerSettings.applicationIdentifier = packageName;
#endif

        // Update the version text in the scene
        if (versionText != null)
        {
            versionText.text = newVersion;
            PlayerPrefs.SetString(NEUR_Constant.NEUR_ApkVersion, newVersion);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogWarning("No TMP_Text component with the tag 'VersionText' found in the scene.");
        }

        Debug.Log("Version number changed to: " + newVersion);
    }
}
