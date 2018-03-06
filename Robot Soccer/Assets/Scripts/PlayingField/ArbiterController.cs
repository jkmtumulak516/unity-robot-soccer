using Assets.Scripts.FuzzyLogic.Arbiter.FuzzySystems;
using Assets.Scripts.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbiterController : MonoBehaviour {

    private ArbiterFLS ArbiterFls;
    public RobotCarController ArbiterRobot;
    public GameObject Ball;
    public Collider[] hits;
    public float RobotBallRadius = 7;
    public LayerMask SphereCastLayerMask;
    Vector3 SphereLoc;
    
	// Use this for initialization
	void Start () {
        this.ArbiterFls = new ArbiterFLS();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(ArbiterRobot != null)
        {
            hits = Physics.OverlapSphere(ArbiterRobot.transform.position, RobotBallRadius, 1 << 10);
            if (hits.Length == 1)
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
        float degree = 25f;
        if (Physics.SphereCast(ArbiterRobot.transform.position, 15f, ArbiterRobot.Team.OpponentGoal.transform.position - ArbiterRobot.transform.position, out hitInfo, Mathf.Infinity, SphereCastLayerMask))
        {

            SphereLoc = SphereCastCenterOnCollision(ArbiterRobot.transform.position, ArbiterRobot.Team.OpponentGoal.transform.position - ArbiterRobot.transform.position, hitInfo.distance);
            
            degree = ComputeDistance(hitInfo.collider.gameObject.transform.position, ArbiterRobot.transform.position, ArbiterRobot.Team.OpponentGoal.transform.position);
           
        }
        return degree;
    }

    private static Vector3 SphereCastCenterOnCollision(Vector3 origin, Vector3 directionCast, float hitInfoDistance)
    {
        return origin + (directionCast.normalized * hitInfoDistance);
    }
    
    float ComputeDistance(Vector3 A, Vector3 B, Vector3 C)
    {
        Vector3 D = (C - B) / Vector3.Distance(C, B);
        Vector3 V = A - B;
        float t = Vector3.Dot(V, D);
        Vector3 P = B + t * D;
        return Vector3.Distance(P, A);
    }


    //private void OnDrawGizmos()
    //{
    //    //if (isShootHit)
    //    //{
    //    //    Gizmos.color = Color.yellow;
    //    //    Gizmos.DrawSphere(SphereLoc, 15f);
    //    //}
    //}
}
