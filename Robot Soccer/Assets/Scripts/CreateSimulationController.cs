﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateSimulationController : MonoBehaviour {

    public Button CreateButton;
    public InputField TitleInput;
    public InputField DescInput;
    public Slider PlayerNoSlider;
    public Dropdown StrategyDrop;
    public Dropdown ActionDrop;
    GameObject ConfigurationHolder;
    // Use this for initialization
    void Start () {
        CreateButton.onClick.AddListener(delegate { CreateSimulation(); });
        ConfigurationHolder = GameObject.Find("ConfigurationHolder");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateSimulation()
    {
        Configuration c = new Configuration();
        c.Title = TitleInput.text;
        c.Description = DescInput.text;
        c.CreationDateTime = DateTime.Now;
        c.ModifiedDateTime = DateTime.Now;
        c.NumberOfRobots = (int) PlayerNoSlider.value;

        Configuration.Serialize(Directory.GetCurrentDirectory() + "\\Saved\\" + c.Title + ".config", c);

        ConfigurationHolder.GetComponent<ConfigurationHolder>().SetConfiguration(c, StrategyDrop.value, ActionDrop.value);

        Debug.Log("Successfully Created Simulation");

        SceneManager.LoadScene("PlayingField");

    }
}
