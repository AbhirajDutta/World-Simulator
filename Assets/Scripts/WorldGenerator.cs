using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{
     public int width = 256;
    public int height = 256;

    public float scale = 20f;

    public Tilemap tilemap;
    public Tile grass;
    public Tile water;

    void Start()
    {
        GenerateWorld();
    }

    void GenerateWorld ()
    {
        

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile tile = CalculateTile(x, y);
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }


    }
    Tile CalculateTile (int x, int y)
    {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / height * scale;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        
        if  (sample < 0.5f)
        {
            return grass;
        }
        else
        {
            return water;
        }
        
        
    }
}
