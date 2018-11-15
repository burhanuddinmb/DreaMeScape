using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece : ScriptableObject{
    public int x;
    public int y;
    public GameObject unit;

    public bool isOccupied
    {
        get { return unit != null; }
    }
}
