using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int numberOfRooms;
    public bool debug;

    private List<GameObject> rooms;

    public enum SpawnRoomLocation
    {
        CENTER,
        LEFT,
        RIGHT,
        TOP,
        BOTTOM
    }

    public void Start()
    {
        rooms = new List<GameObject>();
    }


    public void GenerateRandomLevel(bool numberOfRoomsLock)
    {
        // Randomize all level poperties. Assuming the property is not locked.
        if (numberOfRoomsLock == false) { numberOfRooms = Random.Range(5, 10); }

        // Create the level.
        GenerateLevel();
    }


    /**
     *  Generates terrain for level.
     */
    private void GenerateLevel()
    {
        // Destroy old level before creating a new one.
        DestroyLevel();

        // Create all the rooms.
        for (int i = 0; i < numberOfRooms; i++) { rooms.Add(GenerateRoom()); }

        // Create the first room with a spawn point.
        rooms[0].GetComponent<RoomGenerator>().roomType = RoomGenerator.RoomType.SPAWN;
        rooms[0].GetComponent<RoomGenerator>().GenerateRoom();

        // Create intermediate rooms.
        for (int i = 1; i < numberOfRooms-1; i++) {
            rooms[i].GetComponent<RoomGenerator>().roomType = RoomGenerator.RoomType.SPAWN;
            rooms[i].GetComponent<RoomGenerator>().GenerateRoom();
        }

        // Create the last room with a boss.
        rooms[numberOfRooms - 1].GetComponent<RoomGenerator>().roomType = RoomGenerator.RoomType.BOSS;
        rooms[numberOfRooms - 1].GetComponent<RoomGenerator>().GenerateRoom();
    }


    /**
     *  Creates empty room GameObjects.
     */
    private GameObject GenerateRoom()
    {
        GameObject room = new GameObject();
        room.transform.parent = transform;
        room.AddComponent<RoomGenerator>();
        return room;
    }


    /**
     *  Destroy each room as well as all objects inside of them.
     */
    private void DestroyLevel()
    {
        foreach(GameObject go in rooms){
            DestroyImmediate(go);
        }
        rooms.Clear();
    }


    /**
     *  Sets seed for non-random level generation.
     *  
     *  This function should only be called inside of the LevelEditor class. 
     *  The LevelEditor class is responsible for creating random seeds.
     */
    public void SetSeed(int seed)
    {
        Random.InitState(seed);
    }


}
