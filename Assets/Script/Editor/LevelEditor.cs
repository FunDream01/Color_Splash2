
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(LevelManager))]
public class LevelEditor : Editor
{
    public override void OnInspectorGUI(){

        base.OnInspectorGUI();
        LevelManager manager=(LevelManager)target;
        if (GUILayout.Button("Color")){
            
        }
    }
}
