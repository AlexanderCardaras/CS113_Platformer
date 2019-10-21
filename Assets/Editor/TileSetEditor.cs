using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileSet))]
public class TileSetEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TileSet tileSet = (TileSet)target;
        tileSet.backgroundTile = (GameObject)EditorGUILayout.ObjectField("Background Tile", tileSet.backgroundTile, typeof(GameObject), false);
        tileSet.groundTile = (GameObject)EditorGUILayout.ObjectField("Ground Tile", tileSet.groundTile, typeof(GameObject), false);
        tileSet.pillar = (GameObject)EditorGUILayout.ObjectField("Pillar", tileSet.pillar, typeof(GameObject), false);
    }

}