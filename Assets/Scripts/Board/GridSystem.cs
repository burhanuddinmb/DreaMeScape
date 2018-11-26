using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

//position
public class GridSystem : ComponentSystem {

    private struct gridObjects{
        public GridPiece eachGrid;
        public GridCoordinates position;
    }

    /// <summary>
    /// Handle movement here
    /// </summary>
    protected override void OnUpdate()
    {
        foreach (var item in GetEntities<gridObjects>())
        {
        }
    }
}
