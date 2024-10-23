#if UNITY_EDITOR //Позволяет перенести работу со скриптом в редактор юнити
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DialogGenerator))]

//Класс Editor позволяет создать свой нтерфейс для редактирования объекта (DialogGenerator)
public class DialogueGeneratorEditor : Editor
{
    /// <summary>
    /// Определяет, как будет отображатся поле инспектора для объекта
    /// </summary>
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
