using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGenerator))]
public class LevelScriptEditor : Editor
{
    int seed;
    bool seedLock;
    bool numberOfRoomsLock;

    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();

        LevelGenerator levelGenerator = (LevelGenerator)target;

        // Randomize Level button
        if (GUILayout.Button("Randomize Level"))
        {
            if (seedLock == false) { SetRandomSeed(); }
            levelGenerator.SetSeed(seed);
            levelGenerator.GenerateRandomLevel(numberOfRoomsLock);
        }

        // Debug
        levelGenerator.debug = EditorGUILayout.Toggle("Debug On", levelGenerator.debug);

        // Seed
        EditorGUILayout.BeginHorizontal();
        EditorGUI.BeginDisabledGroup(seedLock == true);
        seed = EditorGUILayout.IntField("Seed", seed);
        EditorGUI.EndDisabledGroup();
        seedLock = EditorGUILayout.Toggle("", seedLock);
        EditorGUILayout.EndHorizontal();

        // Number Of Rooms
        EditorGUILayout.BeginHorizontal();  
        EditorGUI.BeginDisabledGroup(numberOfRoomsLock == true);
        levelGenerator.numberOfRooms = EditorGUILayout.IntField("Number Of Rooms", levelGenerator.numberOfRooms);
        EditorGUI.EndDisabledGroup();
        numberOfRoomsLock = EditorGUILayout.Toggle("", numberOfRoomsLock);
        EditorGUILayout.EndHorizontal();

    }


    /**
     *  sets global variable 'seed' to a random integer
     */
    private void SetRandomSeed()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        seed = Random.Range(0, 10000);
    }
}