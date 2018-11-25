using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPiece : ScriptableObject{
    public int x;
    public int y;
    public GameObject unit = null;

    public bool isDead = false;
    
    //Return true of dead or occupied
    public bool isOccupied
    {
        get { return (unit != null) || (isDead); }
    }
}
