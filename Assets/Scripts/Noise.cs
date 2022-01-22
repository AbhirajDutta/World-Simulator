using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    public Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;

    }
    Color CalculateColor (int x, int y)
    {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / height * scale;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        
        if  (sample < 0.5f)
        {
            return new Color(0, 0, 1);
        }
        else
        {
            return new Color (0, 1, 0);
        }
        
    }
}
