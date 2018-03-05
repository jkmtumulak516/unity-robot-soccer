using Assets.Scripts.FuzzyLogic.Arbiter.FuzzySystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbiterController : MonoBehaviour {

    private ArbiterFLS ArbiterFls;
    public RobotCarController ArbiterRobot;
    public GameObject Ball;

    public float RobotBallRadius = 10;
    int BallLayer;
	// Use this for initialization
	void Start () {
        this.ArbiterFls = new ArbiterFLS();
        BallLayer = LayerMask.GetMask("Ball");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(ArbiterRobot != null)
        {
            
            if (Physics.OverlapSphere(this.transform.position, RobotBallRadius, 1 << BallLayer).Length == 1)
            {

            }else
            {
                //Move towards ball
                ArbiterRobot.DestX = Ball.transform.position.x;
                ArbiterRobot.DestY = Ball.transform.position.z;
            }
        }
	}

    float GetPassStatus()
    {

        return 0f;
    }
}
