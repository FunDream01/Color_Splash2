using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ColorizingObstacle))]
public class ObstacleEditor : Editor
{
     public override void OnInspectorGUI(){

        base.OnInspectorGUI();
        ColorizingObstacle manager=(ColorizingObstacle)target;
        if (GUILayout.Button("Color")){
            manager.SelectColor();
        }
    }
}
