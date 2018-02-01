﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    //Cameras
    public Camera TopViewCamera;
    public Camera LeftRingCamera;
    public Camera RightRingCamera;

    //Buttons
    public Button TopButton;
    public Button LeftButton;
    public Button RightButton;

	// Use this for initialization
	void Start () {
        LeftButton.onClick.AddListener(delegate { SwitchCamera(0); });
        TopButton.onClick.AddListener(delegate { SwitchCamera(1); });
        RightButton.onClick.AddListener(delegate { SwitchCamera(2); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //0 - left 1- top 2- right
    void SwitchCamera(int camera)
    {
        switch (camera)
        {
            case 0:
                //Disable button
                LeftButton.interactable = false;
                TopButton.interactable = true;
                RightButton.interactable = true;
                //Change Camera
                LeftRingCamera.enabled = true;
                TopViewCamera.enabled = false;
                RightRingCamera.enabled = false;
                break;
            case 1:
                //Disable button
                LeftButton.interactable = true;
                TopButton.interactable = false;
                RightButton.interactable = true;
                //Change Camera
                LeftRingCamera.enabled = false;
                TopViewCamera.enabled = true;
                RightRingCamera.enabled = false;
                break;
            case 2:
                //Disable button
                LeftButton.interactable = true;
                TopButton.interactable = true;
                RightButton.interactable = false;
                //Change Camera
                LeftRingCamera.enabled = false;
                TopViewCamera.enabled = false;
                RightRingCamera.enabled = true;
                break;
        }
    }
}
