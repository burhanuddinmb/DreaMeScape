﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndturnController : MonoBehaviour, IPointerDownHandler
{
    public static bool isInteractable;

    GridPieceSelect gridPieceSelect;

    // Start is called before the first frame update
    void Start()
    {
        isInteractable = false;
    }
    void Update()
    {
        if(!GameManager.HaveEnergy())
        {
            //transform.GetComponent<Image>().enabled = true;
        }
        if(DialoguePanelManager.playerControlsUnlocked)
        {
            if (TutorialCards.isTutorialRunning)
            {
                isInteractable = true;
            }
        }        
    } 
  /*  public void OnPointerEnter(PointerEventData eventData)
    {
        if(isInteractable)
        {
            transform.GetComponent<Image>().enabled = true;
        }        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isInteractable)
        {
            transform.GetComponent<Image>().enabled = false;
        }                 
    }*/
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if(isInteractable)
        { 
            GameManager.EndCurrentTurn(); 
            isInteractable = false;            
        }

      //  gridPieceSelect.highlightMoveSpaces

    }
}
