using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField] private float cameraMoveSpeed;

    [SerializeField] private GameObject[] cameraViews;
    private GameObject currentCamera;
    private GameObject prevCamera;
    private int currentCameraIndex;
    private float portionOfJourney;
    private bool moving;
    [SerializeField] private float journeySpeed;

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
        moving = false;
        portionOfJourney = 0.0f;
        currentCameraIndex = 0;
        currentCamera = cameraViews[0];
        prevCamera = currentCamera;
        currHorizVal = 0.0f;
        currVertVal = 0.0f;
	}
	
	// Update is called once per frame
	void Update()
    {

        //check to see if you are moving the camera up, down, left, or right
        MoveCamera(Input.GetAxis("SecondaryCommandHoriz"), Input.GetAxis("SecondaryCommandVert"));
        ZoomCamera(Input.GetAxis("Mouse Scrollwheel"), zoomInMin, zoomOutMax);

        if(Input.GetKey(KeyCode.Q))
        {
            RotateCamera(true);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            RotateCamera(false);
        }

        if (Input.GetMouseButton(2))
        {
            TranslateCamera();
        }
        //SwapCameras(Input.GetKeyDown(KeyCode.L));
        //AdjustCameraValues(currentCamera, prevCamera);
    }

    //takes in input values and moves the camera based on the values
    //positive right if moving right, negative if moving left
    public void MoveCamera(float right, float up)
    {
        if (right > 0 && currHorizVal < horizCap)
        {
            transform.parent.position += transform.right * cameraMoveSpeed * Time.deltaTime;
            currHorizVal += transform.parent.right.magnitude * cameraMoveSpeed * Time.deltaTime;
        }
        else if (right < 0 && currHorizVal > - horizCap)
        {
            transform.parent.position -= transform.right * cameraMoveSpeed * Time.deltaTime;
            currHorizVal -= transform.parent.right.magnitude * cameraMoveSpeed * Time.deltaTime;
        }

        if (up > 0 && currVertVal < vertCap)
        {
            transform.parent.position += transform.parent.up * cameraMoveSpeed * Time.deltaTime;
            currVertVal += transform.parent.up.magnitude * cameraMoveSpeed * Time.deltaTime;
        }
        else if (up < 0 && currVertVal > -vertCap)
        {
            transform.parent.position -= transform.parent.up * cameraMoveSpeed * Time.deltaTime;
            currVertVal -= transform.parent.up.magnitude * cameraMoveSpeed * Time.deltaTime;
        }
    }

    //zoom the camera when adjusting the scrollwheel
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

    public void TranslateCamera()
    {

    }

    public void RotateCamera(bool isLeft)
    {
        //transform.LookAt();
        if (isLeft)
        {
            transform.RotateAround(transform.parent.position, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * 5.0f);
        }
        else
        {
            transform.RotateAround(transform.parent.position, new Vector3(0.0f, -1.0f, 0.0f), 20 * Time.deltaTime * 5.0f);
        }
    }

    public void SwapCameras(float clicked)
    {
        if (clicked > 0)
        {
            prevCamera = cameraViews[currentCameraIndex];
            currentCameraIndex++;
            if (currentCameraIndex >= cameraViews.Length)
            {
                currentCameraIndex = 0;
            }
            currentCamera = cameraViews[currentCameraIndex];
            moving = true;
        }
    }

    public void SwapCameras(bool clicked)
    {
        if (clicked)
        {
            prevCamera = cameraViews[currentCameraIndex];
            currentCameraIndex = ++currentCameraIndex % cameraViews.Length;
            currentCamera = cameraViews[currentCameraIndex];
            moving = true;
        }
    }

    public void AdjustCameraValues(GameObject newCameraView, GameObject prevCamView)
    {
        if (moving)
        {
            if (transform.position != newCameraView.transform.position || transform.rotation != newCameraView.transform.rotation)
            {
                transform.position = Vector3.Lerp(prevCamView.transform.position, newCameraView.transform.position, portionOfJourney);
                transform.rotation = Quaternion.Lerp(prevCamView.transform.rotation, newCameraView.transform.rotation, portionOfJourney);
                portionOfJourney += Time.deltaTime * journeySpeed;
            }
            else
            {
                moving = false;
                portionOfJourney = 0.0f;
            }
        }
    }
}
