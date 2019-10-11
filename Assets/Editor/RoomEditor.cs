using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomGenerator))]
public class RoomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RoomGenerator roomGenerator = (RoomGenerator)target;


        if (GUILayout.Button("Random Room"))
        {
            roomGenerator.GenerateRoom();
        }

        roomGenerator.roomDimensions = EditorGUILayout.Vector2IntField("Dimensions", roomGenerator.roomDimensions);
    }
}