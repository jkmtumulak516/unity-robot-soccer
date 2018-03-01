using System;
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
    public Dropdown LeagueDrop;
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
        switch (LeagueDrop.value)
        {
            case 0:
                c.NumberOfRobots = 3;
                c.FieldHeight = 130f;
                c.FieldWidth = 150f;
                break;
            case 1:
                c.NumberOfRobots = 5;
                c.FieldHeight = 180f;
                c.FieldWidth = 220f;
                break;
            case 2:
                c.NumberOfRobots = 11;
                c.FieldHeight = 280f;
                c.FieldWidth = 400f;
                break;
        }

        Configuration.Serialize(Directory.GetCurrentDirectory() + "\\Saved\\" + c.Title + ".config", c);

        ConfigurationHolder.GetComponent<ConfigurationHolder>().SetConfiguration(c, StrategyDrop.value, ActionDrop.value);

        Debug.Log("Successfully Created Simulation");

        SceneManager.LoadScene("PlayingField");

    }
}
