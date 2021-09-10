using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    float cameraCord;
    void Start()
    {
        cameraCord = (TileMap.mapSizeX -1)/2;
        transform.position = new Vector3(cameraCord, cameraCord, -10);
       
    }
   
}
