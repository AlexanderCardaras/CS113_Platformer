using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


[CustomEditor(typeof(RoomGenerator))]
public class RoomEditor : Editor
{
    GameObject tileObject;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        RoomGenerator roomGenerator = (RoomGenerator)target;

        // Room Dimensions
        // roomGenerator.roomDimensions = EditorGUILayout.Vector2IntField("Room Dimensions", roomGenerator.roomDimensions);
    }
    
}