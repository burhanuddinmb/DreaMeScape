﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMatrix : MonoBehaviour {

    Grid[,] gameGrid;
    int maxX;
    int maxY;
    [SerializeField] GameObject gridPrefab;

    // Use this for initialization
    void Start () {
        maxX = 50;
        maxY = 50;

        CreateGrid();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateGrid()
    {
        gameGrid = new Grid[50, 50];
        for (int x = 0; x < maxX; x++)
        {
            for (int y = 0; y < maxY; y++)
            {
                gameGrid[x, y].x = x;
                gameGrid[x, y].y = y;

                RaycastHit hit;
                Ray rayResult = new Ray(new Vector3(x, 10, y), new Vector3(x, 0, y));
                if (Physics.Raycast(rayResult, out hit, Mathf.Infinity))
                {
                    Instantiate(gridPrefab, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
