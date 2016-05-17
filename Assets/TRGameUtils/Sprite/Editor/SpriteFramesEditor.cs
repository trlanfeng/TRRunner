using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
[CustomEditor(typeof(SpriteFrames))]
public class SpriteFramesEditor : Editor
{
    string newClipName;
    public override void OnInspectorGUI()
    {
        SpriteFrames sf = (SpriteFrames)target;
        //base.OnInspectorGUI();
        EditorGUILayout.LabelField("动画数量：", sf.Clips.Count.ToString());
        EditorGUILayout.BeginHorizontal();
        newClipName = EditorGUILayout.TextField("动画名称：", newClipName);
        if (GUILayout.Button("添加", GUILayout.Width(50)))
        {
            sf.addClip(newClipName);
        }
        EditorGUILayout.EndHorizontal();
        foreach (string key in sf.Clips.Keys)
        {
            EditorGUILayout.Foldout(false, key);
        }
    }
}
