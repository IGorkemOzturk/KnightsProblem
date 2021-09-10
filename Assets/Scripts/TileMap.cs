using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileMap : MonoBehaviour
{
   
   public  TileType[] tileTypes;
    int[,] tiles;

   public static int mapSizeX = 8;
   public static int mapSizeY = 8;
   

    public void Start()
    {
        CreateMap();
        GenerateMapVisual();
    }

    public void CreateMap()
    {
        tiles = new int[mapSizeX, mapSizeY];
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                if ((x + y) % 2 == 0)
                {
                    tiles[x, y] = 0;
                }
                else
                {
                    tiles[x, y] = 1;
                }
            }
        }
    }
    public void GenerateMapVisual()
    {
       
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                TileType tt = tileTypes[tiles[x, y]];
                Instantiate(tt.tileVisualPrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }

  
   

}
