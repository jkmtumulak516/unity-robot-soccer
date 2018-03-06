using Assets.Scripts.FuzzyLogic.Arbiter.FuzzySystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbiterController : MonoBehaviour {

    private ArbiterFLS ArbiterFls;
    public RobotCarController ArbiterRobot;
    public GameObject Ball;
    public Collider[] hits;
    public float RobotBallRadius = 7;
	// Use this for initialization
	void Start () {
        this.ArbiterFls = new ArbiterFLS();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(ArbiterRobot != null)
        {
            hits = Physics.OverlapSphere(ArbiterRobot.transform.position, RobotBallRadius, 1 << 10);
            if (hits    .Length == 1)
            {
                Debug.Log(GetShootStatus());
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

    float GetShootStatus()
    {
        RaycastHit hitInfo;
        float degree = 30f;
        if (Physics.SphereCast(ArbiterRobot.transform.position, 15f, ArbiterRobot.Team.OpponentGoal.transform.position, out hitInfo))
        {
            degree = Vector3.Distance(SphereCastCenterOnCollision(ArbiterRobot.transform.position, ArbiterRobot.Team.OpponentGoal.transform.position, hitInfo.distance),
                hitInfo.collider.gameObject.transform.position);
        }
        return degree;
    }

    private static Vector3 SphereCastCenterOnCollision(Vector3 origin, Vector3 directionCast, float hitInfoDistance)
    {
        return origin + (directionCast.normalized * hitInfoDistance);
    }
}
