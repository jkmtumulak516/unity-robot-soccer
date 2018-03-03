using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TeamController;

public class SimulationManager : MonoBehaviour {

    public GameObject RedTeam;
    public GameObject BlueTeam;

    public Button PlayButton;
    public Button PauseButton;
    public Button StopButton;

    public bool IsStart = false;
    public bool IsPaused = false;

    public float TimeScale = 1f;

    ConfigurationHolder ConfigurationHolder;

	// Use this for initialization
	void Start () {
        ConfigurationHolder = GameObject.Find("ConfigurationHolder").GetComponent<ConfigurationHolder>();
        Initialize();

        PlayButton.onClick.AddListener(delegate { StartSimulation(); });
        PauseButton.onClick.AddListener(delegate { PauseSimulation(); });
        StopButton.onClick.AddListener(delegate { StopSimulation(); });
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    public void Initialize()
    {
        RedTeam.GetComponent<TeamController>().Initialize(TEAM.RED, ConfigurationHolder.c.NumberOfRobots);
        BlueTeam.GetComponent<TeamController>().Initialize(TEAM.BLUE, ConfigurationHolder.c.NumberOfRobots);
    }

    public void StartSimulation()
    {
        //Disable button
        PlayButton.interactable = false;
        PauseButton.interactable = true;
        StopButton.interactable = true;
        
        if (IsPaused) {
            IsPaused = false;
        }

        Time.timeScale = TimeScale;
        IsStart = true;
    }

    public void PauseSimulation()
    {
        PlayButton.interactable = true;
        PauseButton.interactable = false;
        StopButton.interactable = true;

        IsPaused = true;
        Time.timeScale = 0f;
    }

    public void ResetSimulation()
    {
        

    }

    public void StopSimulation()
    {
        PlayButton.interactable = true;
        PauseButton.interactable = false;
        StopButton.interactable = false;

        IsStart = false;
        IsPaused = false;

        RedTeam.GetComponent<TeamController>().DeleteAllChildren();
        BlueTeam.GetComponent<TeamController>().DeleteAllChildren();

        RedTeam.GetComponent<TeamController>().Initialize(TEAM.RED, ConfigurationHolder.c.NumberOfRobots);
        BlueTeam.GetComponent<TeamController>().Initialize(TEAM.BLUE, ConfigurationHolder.c.NumberOfRobots);
    }
}
