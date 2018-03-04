using Assets.Scripts.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitialization : MonoBehaviour {
    public GameObject Floor;
    public GameObject CenterCircle;

   
    ConfigurationHolder ConfigurationHolder;


    // Use this for initialization
    void Start () {
        
        ConfigurationHolder = GameObject.Find("ConfigurationHolder").GetComponent<ConfigurationHolder>();
        switch (ConfigurationHolder.c.NumberOfRobots)
        {
            case 3:
                Floor.transform.localScale = League.Small.Init.Scale;
                CenterCircle.GetComponent<CircleScript>().radius = League.Small.Init.CenterCirleRadius;
                break;
            case 5:
                Floor.transform.localScale = League.Middle.Init.Scale;
                CenterCircle.GetComponent<CircleScript>().radius = League.Middle.Init.CenterCirleRadius;
                break;
            case 11:
                Floor.transform.localScale = League.Large.Init.Scale;
                CenterCircle.GetComponent<CircleScript>().radius = League.Large.Init.CenterCirleRadius;
                break;
        }


    }
	
	// Update is called once per frame
	void Update () {
	}

}
