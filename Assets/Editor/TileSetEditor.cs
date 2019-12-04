using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileSet))]
public class TileSetEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
        /*
        TileSet tileSet = (TileSet)target;
        tileSet.backgroundTile = (GameObject)EditorGUILayout.ObjectField("Background Tile", tileSet.backgroundTile, typeof(GameObject), false);
        tileSet.groundSoloTile = (GameObject)EditorGUILayout.ObjectField("Ground Tile", tileSet.groundSoloTile, typeof(GameObject), false);
        tileSet.pillarCenterTile = (GameObject)EditorGUILayout.ObjectField("Pillar", tileSet.pillarCenterTile, typeof(GameObject), false);
        */
    }

}