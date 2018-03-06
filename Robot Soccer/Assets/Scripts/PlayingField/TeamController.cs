using Assets.Scripts.Game;
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
                Goalie = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Small.GoaliePosition.x, League.Small.GoaliePosition.y, League.Small.GoaliePosition.z * m), q);
                Goalie.GetComponent<RobotCarController>().Initialize(this);
                Goalie.AddComponent<GoalieController>();
                Goalie.transform.SetParent(this.gameObject.transform);

                var rc = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Small.DefenderPosition.x, League.Small.DefenderPosition.y, League.Small.DefenderPosition.z * m), q);
                rc.GetComponent<RobotCarController>().Initialize(this);
                rc.transform.SetParent(this.gameObject.transform);
                Defenders.Add(rc);

                rc = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Small.ForwardPosition.x, League.Small.ForwardPosition.y, League.Small.ForwardPosition.z * m), q);
                rc.GetComponent<RobotCarController>().Initialize(this);
                rc.transform.SetParent(this.gameObject.transform);
                Forward.Add(rc);
                break;
            case 5:
                Goalie = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Middle.GoaliePosition.x, League.Middle.GoaliePosition.y, League.Middle.GoaliePosition.z * m), q);
                Goalie.GetComponent<RobotCarController>().Initialize(this);
                Goalie.AddComponent<GoalieController>();
                Goalie.transform.SetParent(this.gameObject.transform);

                var rd = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Middle.DefenderPosition.x, League.Middle.DefenderPosition.y, League.Middle.DefenderPosition.z * m), q);
                rd.GetComponent<RobotCarController>().Initialize(this);
                rd.transform.SetParent(this.gameObject.transform);
                Defenders.Add(rd);

                rd = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Middle.ForwardPosition.x, League.Middle.ForwardPosition.y, League.Middle.ForwardPosition.z * m), q);
                rd.GetComponent<RobotCarController>().Initialize(this);
                rd.transform.SetParent(this.gameObject.transform);
                Forward.Add(rd);

                for(int i=0; i < League.Middle.MidfielderPosition.Length; i++)
                {
                    rd = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Middle.MidfielderPosition[i].x, League.Middle.MidfielderPosition[i].y, League.Middle.MidfielderPosition[i].z * m), q);
                    rd.GetComponent<RobotCarController>().Initialize(this);
                    rd.transform.SetParent(this.gameObject.transform);
                    Midfielders.Add(rd);
                }
                break;
            case 11:
                Goalie = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Large.GoaliePosition.x, League.Large.GoaliePosition.y, League.Large.GoaliePosition.z * m), q);
                Goalie.GetComponent<RobotCarController>().Initialize(this);
                Goalie.AddComponent<GoalieController>();
                Goalie.transform.SetParent(this.gameObject.transform);
                
                for (int i = 0; i < League.Large.MidfielderPosition.Length; i++)
                {
                    var mid = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Large.MidfielderPosition[i].x, League.Large.MidfielderPosition[i].y, League.Large.MidfielderPosition[i].z * m), q);
                    mid.GetComponent<RobotCarController>().Initialize(this);
                    mid.transform.SetParent(this.gameObject.transform);
                    Midfielders.Add(mid);
                }

                for (int i = 0; i < League.Large.DefenderPosition.Length; i++)
                {
                    var def = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Large.DefenderPosition[i].x, League.Large.DefenderPosition[i].y, League.Large.DefenderPosition[i].z * m), q);
                    def.GetComponent<RobotCarController>().Initialize(this);
                    def.transform.SetParent(this.gameObject.transform);
                    Defenders.Add(def);
                }

                for (int i = 0; i < League.Large.ForwardPosition.Length; i++)
                {
                    var forw = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(League.Large.ForwardPosition[i].x, League.Large.ForwardPosition[i].y, League.Large.ForwardPosition[i].z * m), q);
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
