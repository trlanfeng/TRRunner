using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(Sprite2D))]
public class Sprite2DEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Sprite2D sprite2D = (Sprite2D)target;
        base.OnInspectorGUI();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("ResizeToSet"))
        {
            sprite2D.resizeToSet();
        }
        if (GUILayout.Button("ResizeToOriginal"))
        {
            sprite2D.resizeToOriginal();
        }
        EditorGUILayout.EndHorizontal();
    }
}
