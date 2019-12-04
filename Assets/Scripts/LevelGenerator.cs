using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject tileSetObject;
    public int seed;
    public int numberOfRooms;
    public bool debug;

    private List<GameObject> rooms = new List<GameObject>();
    private int minNumberOfRooms = 5;
    private int maxNumberOfRooms = 10;

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
        ClearLevelObject();
        GenerateLevel();
    }


    public void GenerateRandomLevel(bool numberOfRoomsLock)
    {
        // Randomize all level poperties. Assuming the property is not locked.
        int tempNumberOfRooms = Random.Range(minNumberOfRooms, maxNumberOfRooms);
        if (numberOfRoomsLock == false) { numberOfRooms = tempNumberOfRooms; }

        // Create the level.
        GenerateLevel();
    }


    /**
     *  Generates terrain for level.
     */
    private void GenerateLevel()
    {
        // Destroy old level before creating a new one.
        ClearLevelObject();

        // Create all the rooms.
        for (int i = 0; i < numberOfRooms; i++) { rooms.Add(GenerateRoom()); }

        // Create the first room with a spawn point.
        rooms[0].GetComponent<RoomGenerator>().roomType = RoomGenerator.RoomType.SPAWN;
        rooms[0].GetComponent<RoomGenerator>().GenerateRoom();

        // Create intermediate rooms.
        for (int i = 1; i < numberOfRooms-1; i++) {
            rooms[i].GetComponent<RoomGenerator>().roomType = RoomGenerator.RoomType.CORRIDOR;
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
        room.GetComponent<RoomGenerator>().tileSet = tileSetObject.GetComponent<TileSet>();
        room.transform.name = "Room";
        return room;
    }


    /**
     *  Destroy all objects inside of the level.
     */
    private void ClearLevelObject()
    {
        DestroyLevel();
        for (int i=0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
        
    }


    /**
     *  Destroy each room as well as all objects inside of them.
     */
    private void DestroyLevel()
    {
        if (rooms == null) return;
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
