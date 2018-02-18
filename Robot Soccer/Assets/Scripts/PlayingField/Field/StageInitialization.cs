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
                Floor.transform.localScale = League.Small.Scale;
                CenterCircle.GetComponent<CircleScript>().radius = League.Small.CenterCirleRadius;
                break;
            case 5:
                Floor.transform.localScale = League.Middle.Scale;
                CenterCircle.GetComponent<CircleScript>().radius = League.Middle.CenterCirleRadius;
                break;
            case 11:
                Floor.transform.localScale = League.Middle.Scale;
                CenterCircle.GetComponent<CircleScript>().radius = League.Middle.CenterCirleRadius;
                break;
        }



        //for (int i = 0; i < SMController.c.NumberOfRobots; i++)
        //{
        //    var rc = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), pos[i], Quaternion.Euler(0, 180, 0));
        //    rc.GetComponent<RobotCarController>().Initialize(RobotCarController.TEAM.RED);
        //}
        //for (int i = 0; i < SMController.c.NumberOfRobots; i++)
        //{
        //    var rc = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(pos[i].x, pos[i].y, -pos[i].z), Quaternion.identity);
        //    rc.GetComponent<RobotCarController>().Initialize(RobotCarController.TEAM.BLUE);
        //}

    }
	
	// Update is called once per frame
	void Update () {
	}

}
