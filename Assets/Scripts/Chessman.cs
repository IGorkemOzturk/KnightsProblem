using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{

    public GameObject controller;
    public GameObject movePlate;

    private int xBoard = 1;
    private int yBoard = 1;

    private string player;

    public Sprite knight;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        this.GetComponent<SpriteRenderer>().sprite = knight;
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 1f;
        y *= 1f;

        //x += -2.3f;
        //y += -2.3f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;

    }
    public int GetYBoard()
    {
        return yBoard;

    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }
    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    private void OnMouseUp()
    {
        DestroyMovePlates();
        InitiateMovePlates();
    }
    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates()
    {
        LMovePlate();
    }

    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }

    public void PointMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if(sc.PositionOnBoard(x,y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if(cp==null)
            {
                MovePlateSpawn(x, y);
            }
        }
    }

    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 1;
        y *= 1;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

}
