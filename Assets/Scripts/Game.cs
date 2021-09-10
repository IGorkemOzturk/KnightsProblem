using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject chesspiece;

    private GameObject[,] positions = new GameObject[TileMap.mapSizeX,TileMap.mapSizeY];
    private GameObject player;

    

    private void Start()
    {
        Debug.Log(positions[TileMap.mapSizeX-1, TileMap.mapSizeY-1]);

        GameObject obj= Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);

        SetPosition(obj);
        Chessman cm = obj.GetComponent<Chessman>();

       
        int randomNumX = Random.Range(0, TileMap.mapSizeX);
        int randomNumY = Random.Range(0, TileMap.mapSizeY);
        cm.name = name;
        cm.SetXBoard(randomNumX);
        cm.SetYBoard(randomNumY);
        cm.Activate();
    }
        
    public void SetPosition(GameObject obj) 
    {
        Chessman cm = obj.GetComponent<Chessman>();    
        positions[cm.GetXBoard(),cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x,int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }
    
    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

}
