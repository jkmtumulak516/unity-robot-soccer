using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TeamController;

public class SimulationManager : MonoBehaviour {

    public GameObject RedTeam;
    public GameObject BlueTeam;

    ConfigurationHolder ConfigurationHolder;

	// Use this for initialization
	void Start () {
        ConfigurationHolder = GameObject.Find("ConfigurationHolder").GetComponent<ConfigurationHolder>();
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize()
    {
        RedTeam.GetComponent<TeamController>().Initialize(TEAM.RED, ConfigurationHolder.c.NumberOfRobots);
        BlueTeam.GetComponent<TeamController>().Initialize(TEAM.BLUE, ConfigurationHolder.c.NumberOfRobots);
    }

    public void StartSimulation()
    {

    }

    public void PauseSimulation()
    {

    }

    public void ResetSimulation()
    {

    }

    public void StopSimulation()
    {

    }
}
