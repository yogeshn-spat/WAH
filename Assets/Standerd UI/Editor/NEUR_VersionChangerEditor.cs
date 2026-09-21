using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NEUR_VersionChanger))]
public class NEUR_VersionChangerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector (this shows the public fields like newVersion, productName, etc.)
        DrawDefaultInspector();

        // Reference to the target component (NEUR_VersionChanger script)
        NEUR_VersionChanger versionChanger = (NEUR_VersionChanger)target;

        // Add a button in the inspector
        if (GUILayout.Button("Change Version"))
        {
            // Call the ChangeVersionNumber method when button is clicked
            versionChanger.ChangeVersionNumber();
        }
    }
}
