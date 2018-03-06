using Assets.Scripts.FuzzyLogic.GameState.FuzzySystems;
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

    GameStateFLS GameStateFLS;

    // Use this for initialization
	void Start () {
        GameStateFLS = new GameStateFLS();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        NearestBlue = BlueTeam.GetClosestFromBall();
        NearestRed = RedTeam.GetClosestFromBall();

        var blueState = GetStateBlue();
        var redState = GetStateRed();

        RedTeam.UpdateStrategy((redState > blueState) ? TeamController.STRATEGY.OFFENSE : TeamController.STRATEGY.DEFENSE, NearestRed);
        BlueTeam.UpdateStrategy((blueState > redState) ? TeamController.STRATEGY.OFFENSE : TeamController.STRATEGY.DEFENSE, NearestBlue);
        //Debug.Log("Blue : " + blueState + " ||||   Red : " + redState);
    }
    
    float GetStateBlue()
    {
        //Difference of the nearest distances between blue and red robots from ball
        var ND = (Vector3.Distance(NearestBlue.transform.position , Ball.transform.position) - Vector3.Distance(NearestRed.transform.position , Ball.transform.position));

        //Orientation of the blue robot from the ball
        var O = (float) System.Math.Abs(Angle.ComputeRelativeAngle(NearestBlue.transform.eulerAngles.y, NearestBlue.transform.position.x, NearestBlue.transform.position.z, Ball.transform.position.x, Ball.transform.position.z));

        //Calculated distance of the ball from the red goal
        var D = Vector3.Distance(Ball.transform.position, BlueTeam.OpponentGoal.transform.position);

        var state = GameStateFLS.GetState(O, ND, D);

        return state;
    }
    
    float GetStateRed()
    {
        //Difference of the nearest distances between red and blue robots from ball
        var ND = (Vector3.Distance(NearestRed.transform.position , Ball.transform.position) - Vector3.Distance(NearestBlue.transform.position , Ball.transform.position));

        //Orientation of the red robot from the ball
        var O = (float) System.Math.Abs(Angle.ComputeRelativeAngle(NearestRed.transform.eulerAngles.y, NearestRed.transform.position.x, NearestRed.transform.position.z, Ball.transform.position.x, Ball.transform.position.z));

        //Calculated distance of the ball from the blue goal
        var D = Vector3.Distance(Ball.transform.position, RedTeam.OpponentGoal.transform.position);

        var state = GameStateFLS.GetState(O, ND, D);

        return state;
    }

}
