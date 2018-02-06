using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitialization : MonoBehaviour {
    Dictionary<int, Vector3[]> Positions;
    SimulationManagerController SMController;

    //Positions
    Vector3 _goalie = new Vector3(0, 2, 65.33f);
    Vector3 _defender1 = new Vector3(30.36f, 2, 44.5f);
    Vector3 _defender2 = new Vector3(0, 2, 48.7f);
    Vector3 _defender3 = new Vector3(-30.36f, 2, 44.5f);
    Vector3 _middle1 = new Vector3(47.3f, 2, 30.2f);
    Vector3 _middle2 = new Vector3(15.9f, 2, 30.2f);
    Vector3 _middle3 = new Vector3(-15.9f, 2, 30.2f);
    Vector3 _middle4 = new Vector3(-47.3f, 2, 30.2f);
    Vector3 _front1 = new Vector3(30.36f, 2, 14.04f);
    Vector3 _front2 = new Vector3(0, 2, 14.04f);
    Vector3 _front3 = new Vector3(-30.36f, 2, 14.04f);

    // Use this for initialization
    void Start () {
        InitPositionDict();
        SMController = GameObject.Find("SimulationManager").GetComponent<SimulationManagerController>();
        Vector3[] pos;
        Positions.TryGetValue(SMController.c.NumberOfRobots, out pos);

        for(int i = 0; i < SMController.c.NumberOfRobots; i++)
        {
            var rc = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), pos[i], Quaternion.Euler(0, 180, 0));
            rc.GetComponent<RobotCarController>().Initialize(RobotCarController.TEAM.RED);
        }
        for (int i = 0; i < SMController.c.NumberOfRobots; i++)
        {
            var rc = (GameObject)Object.Instantiate(Resources.Load("RobotCar"), new Vector3(pos[i].x, pos[i].y, -pos[i].z), Quaternion.identity);
            rc.GetComponent<RobotCarController>().Initialize(RobotCarController.TEAM.BLUE);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitPositionDict()
    {
        Positions = new Dictionary<int, Vector3[]>();
        Positions.Add(3, new Vector3[]{ _goalie, _front1, _front3});
        Positions.Add(4, new Vector3[] { _goalie, _middle1, _middle4, _front2});
        Positions.Add(5, new Vector3[] { _goalie, _defender2, _middle1, _middle4, _front2 });
        Positions.Add(6, new Vector3[] { _goalie, _defender1, _defender3, _middle1, _middle4, _front2 });
        Positions.Add(7, new Vector3[] { _goalie, _defender1, _defender2, _defender3, _middle1, _middle4, _front2 });
        Positions.Add(8, new Vector3[] { _goalie, _defender1, _defender2, _defender3, _middle1, _middle4, _front1, _front3 });
        Positions.Add(9, new Vector3[] { _goalie, _defender1, _defender2, _defender3, _middle1, _middle2, _middle3, _middle4, _front2 });
        Positions.Add(10, new Vector3[] { _goalie, _defender1, _defender2, _defender3, _middle1, _middle2, _middle3, _middle4, _front1, _front3 });
        Positions.Add(11, new Vector3[] { _goalie, _defender1, _defender2, _defender3, _middle1, _middle2, _middle3, _middle4, _front1, _front2, _front3 });
    }
}
