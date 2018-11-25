using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMatrix : MonoBehaviour {

    GridPiece[,] gameGrid;
    [SerializeField] GameObject gridPrefab;

    int maxX;
    int maxY;
    float widthOfGrid;
    

    // Use this for initialization
    void Start () {
        maxX = 31;
        maxY = 13;

        //As the prefab needs to be symmetrical accross x and z, 
        //we can choose any one of the two
        widthOfGrid = gridPrefab.transform.localScale.x;

        CreateGrid();
    }
	
	// Update is called once per frame
	void Update () {
		 
	}

    void CreateGrid()
    {
        gameGrid = new GridPiece[maxX, maxY];
        Vector3 placementOrigin = Vector3.zero;
        GameObject createdGridPieces;

        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        Debug.Log("a:" + int.MaxValue + " b:" + layerMask);
        Vector3 directionVector = -Vector3.up;

        for (int x = 0; x < maxX; x++)
        {
            for (int y = 0; y < maxY; y++)
            {
                gameGrid[x, y] = ScriptableObject.CreateInstance<GridPiece>();
                gameGrid[x, y].x = x;
                gameGrid[x, y].y = y;

                placementOrigin = new Vector3((float)x* widthOfGrid, 20, (float)y* widthOfGrid);

                RaycastHit hit;
                Ray rayResult = new Ray(placementOrigin, directionVector);
                if (Physics.Raycast(rayResult, out hit))
                {
                    createdGridPieces = Instantiate(gridPrefab, hit.point, Quaternion.identity, transform);
                    createdGridPieces.name = "GridX" + x + "Y" + y;
                }
                else
                {
                    gameGrid[x, y].isDead = true;
                }
            }
        }
    }
}
