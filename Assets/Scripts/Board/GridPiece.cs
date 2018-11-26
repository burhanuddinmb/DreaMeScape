using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keep track of the units held by each grid
/// </summary>
public class GridPiece : MonoBehaviour{

    public GameObject unit = null;
    public bool isDead = false;

    /// <summary>
    /// Return true if occupied
    /// </summary>
    public bool isOccupied
    {
        get { return (unit != null) || isDead; }
    }
}
