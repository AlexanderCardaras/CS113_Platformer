using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public Vector2Int roomDimensions;
    public RoomType roomType;
    public TileSet tileSet;

    public enum RoomType
    {
        SPAWN,
        CORRIDOR,
        BOSS
    }

    //TODO: Add logic to fill room with textures
    public void GenerateRoom()
    {
        roomDimensions = new Vector2Int((int)Random.Range(5,10), (int)Random.Range(5,10));

        switch (roomType)
        {
            case RoomType.SPAWN:
                GenerateSpawnRoom();
                break;

            case RoomType.CORRIDOR:

                break;

            case RoomType.BOSS:

                break;

            default:
                Debug.LogError("Generate Room Unknown RoomType: " + roomType);
                break;
        }
    }

    private void GenerateSpawnRoom()
    {
        GameObject background = Instantiate(tileSet.backgroundTile) as GameObject;
        background.transform.parent = transform;
    }


}
