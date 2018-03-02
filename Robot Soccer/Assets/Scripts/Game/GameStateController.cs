using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {

    public TeamController BlueTeam;
    public TeamController RedTeam;
    public GameObject Ball;

    RobotCarController NearestBlue;
    RobotCarController NearestRed;

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        NearestBlue = BlueTeam.GetClosestFromBall();
        NearestRed = RedTeam.GetClosestFromBall();
    }

    //TODO Intergrate GetState with StateFLS
    int GetStateBlue()
    {
        //Difference of the nearest distances between blue and red robots from ball
        var ND = ((NearestBlue.transform.position - Ball.transform.position).sqrMagnitude - (NearestRed.transform.position - Ball.transform.position).sqrMagnitude);

        //Orientation of the blue robot from the ball
        var O = System.Math.Abs(Angle.ComputeRelativeAngle(NearestBlue.transform.eulerAngles.y, NearestBlue.transform.position.x, NearestBlue.transform.position.z, Ball.transform.position.x, Ball.transform.position.z));

        //Calculated distance of the ball from the red goal
        var D = Vector3.Distance(Ball.transform.position, BlueTeam.OpponentGoal.transform.position);
        return 1;
    }

    //TODO Intergrate GetState with StateFLS
    int GetStateRed()
    {
        //Difference of the nearest distances between red and blue robots from ball
        var ND = ((NearestRed.transform.position - Ball.transform.position).sqrMagnitude - (NearestBlue.transform.position - Ball.transform.position).sqrMagnitude);

        //Orientation of the red robot from the ball
        var O = System.Math.Abs(Angle.ComputeRelativeAngle(NearestRed.transform.eulerAngles.y, NearestRed.transform.position.x, NearestRed.transform.position.z, Ball.transform.position.x, Ball.transform.position.z));

        //Calculated distance of the ball from the blue goal
        var D = Vector3.Distance(Ball.transform.position, RedTeam.OpponentGoal.transform.position);

        return 1;
    }

}
