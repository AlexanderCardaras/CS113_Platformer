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
        //roomDimensions = new Vector2Int(Random.Range(5,10), Random.Range(5,10));
        roomDimensions = new Vector2Int(10, 5);

        switch (roomType)
        {
            case RoomType.SPAWN:
                GenerateSpawnRoom();
                break;

            case RoomType.CORRIDOR:
                //GenerateCorridor();
                break;

            case RoomType.BOSS:
                //GenerateBossRoom();
                break;

            default:
                Debug.LogError("Generate Room Unknown RoomType: " + roomType);
                break;
        }
    }

    private void GenerateSpawnRoom()
    {
        GameObject background;
        // Fill room with background tiles
        for (int x = 0; x < roomDimensions.x; x++)
        {
            for (int y = 0; y < roomDimensions.y; y++)
            {
                background = Instantiate(tileSet.backgroundTile) as GameObject;
                background.transform.parent = transform;
                background.transform.localPosition = new Vector3(x, y, 0);
            }
        }

        // Populate Ground Tiles
        for (int x = 0; x < roomDimensions.x; x++)
        {
            for (int y = 0; y < roomDimensions.y; y++)
            {
                if (y == 0)
                {
                    background = Instantiate(tileSet.groundSoloTile) as GameObject;
                    background.transform.parent = transform;
                    background.transform.localPosition = new Vector3(x, y, 0);
                }
                
            }
        }

        background = Instantiate(tileSet.playerSpawnTile) as GameObject;
        background.transform.parent = transform;
        background.transform.localPosition = new Vector3(5, 1, 0);

    }

    private void GenerateCorridor()
    {
        GameObject background = Instantiate(tileSet.backgroundTile) as GameObject;
        background.transform.parent = transform;
    }

    private void GenerateBossRoom()
    {
        GameObject background = Instantiate(tileSet.backgroundTile) as GameObject;
        background.transform.parent = transform;
    }

}
