using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

//position
public class GridSystem : ComponentSystem {

    private struct gridObjects{
        public Grid eachBox;
    }

    protected override void OnUpdate()
    {
        foreach (var item in GetEntities<gridObjects>())
        {

        }
    }

    // Use this for initialization
    void Start ()
    {
        
	}
	
}
