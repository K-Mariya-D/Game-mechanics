#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DialogGenerator))]

public class DialogueGeneratorEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GUILayout.Space(15);
        DialogGenerator e = (DialogGenerator)target;
        if (GUILayout.Button("Generate Dialogue XML"))
        {
            e.Generate();
        }
    }
}
#endif
