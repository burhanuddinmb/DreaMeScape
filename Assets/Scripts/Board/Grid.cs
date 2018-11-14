using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirdPiece{
    public int x;
    public int y;
    public GameObject unit;

    public GirdPiece(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool isOccupied
    {
        get { return unit != null; }
    }
}
