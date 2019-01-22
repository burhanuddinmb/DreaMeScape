﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRadius : MonoBehaviour
{
    List<Transform> gridsToHighlight;
    public int cannonRadius = 5;

    // Use this for initialization
    void Start()
    {
        gridsToHighlight = new List<Transform>();
        GetGridRadius();
    }

    void GetGridRadius()
    {
        UnitCoordinates gamePiece = gameObject.GetComponent<UnitCoordinates>();
        int row = gamePiece.x;
        int col = gamePiece.y;

        int tempRow, tempCol;
        for (int i = -cannonRadius; i <= cannonRadius; i++)
        {
            for (int j = -cannonRadius; j <= cannonRadius; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }
                tempRow = row + i;
                tempCol = col + j;
                if (GameObject.Find("gridRow" + tempRow + "Column" + tempCol))
                {
                    // Debug.Log(GameObject.Find("gridRow" + tempRow + "Column" + tempCol).transform.childCount);
                    gridsToHighlight.Add(GameObject.Find("gridRow" + tempRow + "Column" + tempCol).transform.GetChild(2));
                }
            }
        }
    }

    public void HighlightGrids()
    {
        foreach (var item in gridsToHighlight)
        {
            item.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void RemoveHighlights()
    {
        foreach (var item in gridsToHighlight)
        {
            item.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
