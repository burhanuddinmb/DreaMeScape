﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField] private float cameraMoveSpeed;

    [SerializeField] private float horizCap;
    [SerializeField] private float vertCap;
    private float currHorizVal;
    private float currVertVal;

    [SerializeField] private float zoomOutMax;
    [SerializeField] private float zoomInMin;
    [SerializeField] private float scrollSpeed;

	// Use this for initialization
	void Start()
    {
        horizCap = 12.0f;
        vertCap = 5.0f;
        currHorizVal = 0.0f;
        currVertVal = 0.0f;
	}
	
	// Update is called once per frame
	void Update()
    {

        //check to see if you are moving the camera up, down, left, or right
        MoveCamera(Input.GetAxis("SecondaryCommandHoriz"), Input.GetAxis("SecondaryCommandVert"));
        ZoomCamera(Input.GetAxis("Mouse Scrollwheel"), zoomInMin, zoomOutMax);
    }

    //takes in input values and moves the camera based on the values
    public void MoveCamera(float right, float up)
    {
        if (right > 0 && currHorizVal < horizCap)
        {
            transform.position += transform.right * cameraMoveSpeed * Time.deltaTime;
            currHorizVal += transform.right.magnitude * cameraMoveSpeed * Time.deltaTime;
        }
        else if (right < 0 && currHorizVal > - horizCap)
        {
            transform.position += -transform.right * cameraMoveSpeed * Time.deltaTime;
            currHorizVal -= transform.right.magnitude * cameraMoveSpeed * Time.deltaTime;
        }

        if (up > 0 && currVertVal < vertCap)
        {
            transform.position += transform.up * cameraMoveSpeed * Time.deltaTime;
            currVertVal += transform.right.magnitude * cameraMoveSpeed * Time.deltaTime;
        }
        else if (up < 0 && currVertVal > -vertCap)
        {
            transform.position += -transform.up * cameraMoveSpeed * Time.deltaTime;
            currVertVal -= transform.right.magnitude * cameraMoveSpeed * Time.deltaTime;
        }
    }

    public void ZoomCamera(float mouseScroll, float min, float max)
    {
        if (gameObject.GetComponent<Camera>() != null)
        {
            Camera obtainedCam = gameObject.GetComponent<Camera>();
            if (mouseScroll > 0 && obtainedCam.orthographicSize > min)
            {
                obtainedCam.orthographicSize -= scrollSpeed;
            }
            else if (mouseScroll < 0 && obtainedCam.orthographicSize < max)
            {
                obtainedCam.orthographicSize += scrollSpeed;
            }
        }
    }
}
