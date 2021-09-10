using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public int input;
    public string theName;
    public GameObject inputField;
  

    public void TextBox()
    {
        theName = inputField.GetComponent<Text>().text;
        input = int.Parse(theName);
        if( input < 4 || input > 16) //variable convertion didnt work well in if statement
        {         
            SceneManager.LoadScene("Menu");
            
        }
        else
        {
            TileMap.mapSizeX = int.Parse(theName);
            TileMap.mapSizeY = int.Parse(theName);
            SceneManager.LoadScene("Play");
        }

    }
}
