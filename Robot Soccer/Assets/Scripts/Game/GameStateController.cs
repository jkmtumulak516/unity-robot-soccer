using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {

    public TeamController BlueTeam;
    public TeamController RedTeam;
    public GameObject Ball;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //TODO Intergrate GetState with StateFLS
    int GetStateBlue()
    {
        var nearestBlue = BlueTeam.GetClosestFromBall();
        var nearestRed = RedTeam.GetClosestFromBall();


        //Difference of the nearest distances between blue and red robots from ball
        var ND = ((nearestBlue.transform.position - Ball.transform.position).sqrMagnitude - (nearestRed.transform.position - Ball.transform.position).sqrMagnitude);

        //Orientation of the blue robot from the ball
        var O = System.Math.Abs(Angle.ComputeRelativeAngle(nearestBlue.transform.eulerAngles.y, nearestBlue.transform.position.x, nearestBlue.transform.position.z, Ball.transform.position.x, Ball.transform.position.z));

        //Calculated distance of the ball from the red goal
        var D = Vector3.Distance(Ball.transform.position, BlueTeam.OpponentGoal.transform.position);
        return 1;
    }

}
