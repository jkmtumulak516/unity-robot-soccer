﻿using Assets.Scripts.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour {

    public enum TEAM : int { BLUE, RED };
    public GameObject Goal;
    public GameObject OpponentGoal;

    public GameObject Ball;

    public TEAM team;
    public List<GameObject> Defenders;
    public List<GameObject> Midfielders;
    public List<GameObject> Forward;
    public GameObject Goalie;
    
	// Use this for initialization
	void Start () {
        
        Goalie = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       

    }

    public void Initialize(TEAM teamColor, int noOfRobots )
    {
        Defenders = new List<GameObject>();
        Midfielders = new List<GameObject>();
        Forward = new List<GameObject>();
        team = teamColor;
        Quaternion q = Quaternion.identity;
        int m = -1;
        if (team == TEAM.RED)
        {
            m = 1;
            q = Quaternion.Euler(0, 180, 0);
        }
            
        switch (noOfRobots)
        {
            case 3:
                Goalie = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Small.Init.GoaliePosition.x, League.Small.Init.GoaliePosition.y, League.Small.Init.GoaliePosition.z * m), q);
                Goalie.GetComponent<RobotCarController>().Initialize(this);
                Goalie.transform.SetParent(this.gameObject.transform);
                GameObject rc = null;
                if(team == TEAM.RED)
                    rc = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Small.Init.DefenderPosition.x, League.Small.Init.DefenderPosition.y, League.Small.Init.DefenderPosition.z * m), q);
                else
                    rc = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), League.Small.Init.DefenderKickOffPosition, q);
                rc.GetComponent<RobotCarController>().Initialize(this);
                rc.transform.SetParent(this.gameObject.transform);
                Defenders.Add(rc);

                if (team == TEAM.RED)
                    rc = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Small.Init.ForwardPosition.x, League.Small.Init.ForwardPosition.y, League.Small.Init.ForwardPosition.z * m), q);
                else
                    rc = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), League.Small.Init.ForwardKickOffPosition, Quaternion.Euler(0, -90, 0));
                rc.GetComponent<RobotCarController>().Initialize(this);
                rc.transform.SetParent(this.gameObject.transform);
                Forward.Add(rc);
                break;
            case 5:
                Goalie = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Middle.Init.GoaliePosition.x, League.Middle.Init.GoaliePosition.y, League.Middle.Init.GoaliePosition.z * m), q);
                Goalie.GetComponent<RobotCarController>().Initialize(this);
                Goalie.transform.SetParent(this.gameObject.transform);

                var rd = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Middle.Init.DefenderPosition.x, League.Middle.Init.DefenderPosition.y, League.Middle.Init.DefenderPosition.z * m), q);
                rd.GetComponent<RobotCarController>().Initialize(this);
                rd.transform.SetParent(this.gameObject.transform);
                Defenders.Add(rd);

                rd = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Middle.Init.ForwardPosition.x, League.Middle.Init.ForwardPosition.y, League.Middle.Init.ForwardPosition.z * m), q);
                rd.GetComponent<RobotCarController>().Initialize(this);
                rd.transform.SetParent(this.gameObject.transform);
                Forward.Add(rd);

                for(int i=0; i < League.Middle.Init.MidfielderPosition.Length; i++)
                {
                    rd = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Middle.Init.MidfielderPosition[i].x, League.Middle.Init.MidfielderPosition[i].y, League.Middle.Init.MidfielderPosition[i].z * m), q);
                    rd.GetComponent<RobotCarController>().Initialize(this);
                    rd.transform.SetParent(this.gameObject.transform);
                    Midfielders.Add(rd);
                }
                break;
            case 11:
                Goalie = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Large.Init.GoaliePosition.x, League.Large.Init.GoaliePosition.y, League.Large.Init.GoaliePosition.z * m), q);
                Goalie.GetComponent<RobotCarController>().Initialize(this);
                Goalie.transform.SetParent(this.gameObject.transform);
                
                for (int i = 0; i < League.Large.Init.MidfielderPosition.Length; i++)
                {
                    var mid = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Large.Init.MidfielderPosition[i].x, League.Large.Init.MidfielderPosition[i].y, League.Large.Init.MidfielderPosition[i].z * m), q);
                    mid.GetComponent<RobotCarController>().Initialize(this);
                    mid.transform.SetParent(this.gameObject.transform);
                    Midfielders.Add(mid);
                }

                for (int i = 0; i < League.Large.Init.DefenderPosition.Length; i++)
                {
                    var def = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Large.Init.DefenderPosition[i].x, League.Large.Init.DefenderPosition[i].y, League.Large.Init.DefenderPosition[i].z * m), q);
                    def.GetComponent<RobotCarController>().Initialize(this);
                    def.transform.SetParent(this.gameObject.transform);
                    Defenders.Add(def);
                }

                for (int i = 0; i < League.Large.Init.ForwardPosition.Length; i++)
                {
                    var forw = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Large.Init.ForwardPosition[i].x, League.Large.Init.ForwardPosition[i].y, League.Large.Init.ForwardPosition[i].z * m), q);
                    forw.GetComponent<RobotCarController>().Initialize(this);
                    forw.transform.SetParent(this.gameObject.transform);
                    Forward.Add(forw);
                }

                break;
        }
    }

    //TODO Implement UpdateStrategy (Defense)
    public void UpdateStrategy()
    {

    }

    //TODO Implement UpdateStrategy (Offense with arbiter)
    public void UpdateStrategy(RobotCarController arbiterRobot)
    {

    }

    
    public RobotCarController GetClosestFromBall()
    {
        var ballPosition = Ball.transform.position;
        GameObject closest = Forward[0];
        var prevMagnitude = (closest.transform.position - ballPosition).sqrMagnitude;

        foreach (GameObject robot in Forward)
        {
            var diff = (robot.transform.position - ballPosition).sqrMagnitude;
            if(diff < prevMagnitude)
            {
                closest = robot;
                prevMagnitude = diff;
            }
        }

        foreach (GameObject robot in Midfielders)
        {
            var diff = (robot.transform.position - ballPosition).sqrMagnitude;
            if (diff < prevMagnitude)
            {
                closest = robot;
                prevMagnitude = diff;
            }
        }

        foreach (GameObject robot in Defenders)
        {
            var diff = (robot.transform.position - ballPosition).sqrMagnitude;
            if (diff < prevMagnitude)
            {
                closest = robot;
                prevMagnitude = diff;
            }
        }

        return closest.GetComponent<RobotCarController>();
    }

    public void DeleteAllChildren()
    {
        foreach(Transform children in this.transform)
        {
            Destroy(children.gameObject);
        }
    }
}
