using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundHandler : MonoBehaviour
{
    public GameObject red_block;
    public GameObject green_block;
    public int width = 100;
    public int height = 100;
    public Vector3 scale;
    public Vector3 tile_scale;
    public Vector3 position_offset;

    void Start()
    {
        GameObject p = new GameObject();
        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject go = Instantiate(red_block);
                go.transform.parent = p.transform;
                go.transform.position = new Vector3(i, j, 0);
                go.transform.localScale = tile_scale;
                go.GetComponent<SpriteRenderer>().sortingOrder = -1;
            }
        }
        p.transform.localScale = new Vector3(scale.x * (1 / tile_scale.x), scale.y * (1 / tile_scale.y), scale.z * (1 / tile_scale.z));
        p.transform.position = position_offset;
    }
}
