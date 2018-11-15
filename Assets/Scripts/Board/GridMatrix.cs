using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMatrix : MonoBehaviour {

    GridPiece[,] gameGrid;
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
        gameGrid = new GridPiece[maxX, maxY];


        for (int x = 0; x < maxX; x++)
        {
            for (int y = 0; y < maxY; y++)
            {
                gameGrid[x, y] = GridPiece.CreateInstance<GridPiece>();
                gameGrid[x, y].x = x;
                gameGrid[x, y].y = y;

                Instantiate(gridPrefab, new Vector3(x, 2, y), Quaternion.identity);
            }
        }
    }
}
