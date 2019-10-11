using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public Vector2Int roomDimensions;
    public RoomType roomType;

    public enum RoomType
    {
        SPAWN,
        CORRIDOR,
        BOSS
    }


    //TODO: Add logic to fill room with textures
    public void GenerateRoom()
    {
        switch (roomType)
        {
            case RoomType.SPAWN:

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


}
