using Assets.Scripts.FuzzyLogic.Arbiter.FuzzySystems;
using Assets.Scripts.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbiterController : MonoBehaviour {

    ArbiterFLS ArbiterFls;
    public enum ACTION : int { DRIBBLE, PASS, SHOOT}
    public ACTION Action;
    public RobotCarController ArbiterRobot;
    public GameObject Ball;
    public Collider[] hits;
    public float RobotBallRadius = 1;
    public LayerMask SphereCastLayerMask;
    Vector3 SphereLoc;
    
	// Use this for initialization
	void Start () {
        this.ArbiterFls = new ArbiterFLS();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (ArbiterFls == null)
            ArbiterFls = new ArbiterFLS();
        if(ArbiterRobot != null)
        {
            hits = Physics.OverlapSphere(ArbiterRobot.transform.position, RobotBallRadius, 1 << 10);
            if (hits.Length == 1)
            {
                Collider bestTeamMate = null;
                
                var shoot = GetShootStatus();
                var pass = GetPassStatus(out bestTeamMate);
                var ballX = (ArbiterRobot.Team.Team == TeamController.TEAM.RED) ? (-Ball.transform.position.z) : Ball.transform.position.z;
                var ballY = Ball.transform.position.x;
                var priority = ArbiterFls.GetPriority(shoot, pass, ballX, ballY);

                if(priority > 68)
                {
                    Action = ACTION.SHOOT;
                    var ArbiterBallOrientation = Angle.ComputeRelativeAngle(ArbiterRobot.transform.eulerAngles.y, ArbiterRobot.transform.position.x, ArbiterRobot.transform.position.y, Ball.transform.position.x, Ball.transform.position.y);
                    var ArbiterGoalOrientation = Angle.ComputeRelativeAngle(ArbiterRobot.transform.eulerAngles.y, ArbiterRobot.transform.position.x, ArbiterRobot.transform.position.y, ArbiterRobot.Team.OpponentGoal.transform.position.x, ArbiterRobot.Team.OpponentGoal.transform.position.y);
                    //Ball is front of robot
                    if (Math.Abs(ArbiterBallOrientation) <= 22)
                    {
                        
                        
                        if (Math.Abs(ArbiterGoalOrientation) <= 20)
                        {
                            ArbiterRobot.Shove = true;
                        }
                        else
                        {
                            ArbiterRobot.Spin = (ArbiterGoalOrientation < 0) ? -1 : 1;

                        }
                    }
                    else
                    {
                        ArbiterRobot.Spin = (ArbiterGoalOrientation < 0) ? -1 : 1;
                    }

                } else if (priority > 34)
                {
                    Action = ACTION.PASS;
                    var ArbiterBallOrientation = Angle.ComputeRelativeAngle(ArbiterRobot.transform.eulerAngles.y, ArbiterRobot.transform.position.x, ArbiterRobot.transform.position.y, Ball.transform.position.x, Ball.transform.position.y);
                    
                    //Ball is front of robot
                    if (Math.Abs(ArbiterBallOrientation) <= 10)
                    {
                        if(bestTeamMate != null)
                        {
                            var ArbiterTeamMateOrientation = Angle.ComputeRelativeAngle(ArbiterRobot.transform.eulerAngles.y, ArbiterRobot.transform.position.x, ArbiterRobot.transform.position.y, bestTeamMate.gameObject.transform.position.x, bestTeamMate.gameObject.transform.position.y);
                            if(Math.Abs(ArbiterTeamMateOrientation) <= 20)
                            {
                                ArbiterRobot.Shove = true;
                            }
                            else
                            {
                                ArbiterRobot.Spin = (ArbiterTeamMateOrientation < 0) ? -1 : 1;
                                
                            }
                        }
                    }else
                    {
                        if (bestTeamMate != null)
                        {
                            var ArbiterTeamMateOrientation = Angle.ComputeRelativeAngle(ArbiterRobot.transform.eulerAngles.y, ArbiterRobot.transform.position.x, ArbiterRobot.transform.position.y, bestTeamMate.gameObject.transform.position.x, bestTeamMate.gameObject.transform.position.y);
                            ArbiterRobot.Spin = (ArbiterTeamMateOrientation < 0) ? -1 : 1;
                        }
                    }
                }
                else
                {
                    Action = ACTION.DRIBBLE;
                    ArbiterRobot.DestX = ArbiterRobot.Team.OpponentGoal.transform.position.x;
                    ArbiterRobot.DestY = ArbiterRobot.Team.OpponentGoal.transform.position.z;

                }
                
            }
            else
            {

                //Move towards ball
                ArbiterRobot.DestX = Ball.transform.position.x;
                ArbiterRobot.DestY = Ball.transform.position.z;
            }
        }
	}

    float GetPassStatus(out Collider bestTeamMate)
    {
        float degree = 0f;
        bestTeamMate = null;
        int layer = (ArbiterRobot.Team.Team == TeamController.TEAM.RED) ? LayerMask.GetMask("Red Team") : LayerMask.GetMask("Blue Team");
        Collider[] teamMates = Physics.OverlapSphere(this.ArbiterRobot.transform.forward * 75f, 75f, layer);
        if(teamMates.Length > 0)
        {
            foreach(var t in teamMates)
            {
                
                var status = GetStatus(t.transform.position);
                if(status > degree)
                {
                    degree = status;
                    bestTeamMate = t;
                }
                
            }
        }
        return degree;
    }

    float GetShootStatus()
    {
        return GetStatus(ArbiterRobot.Team.OpponentGoal.transform.position);
    }

    float GetStatus(Vector3 target)
    {
        RaycastHit hitInfo;
        float degree = 25f;
        if (Physics.SphereCast(ArbiterRobot.transform.position, 15f, target - ArbiterRobot.transform.position, out hitInfo, Mathf.Infinity, SphereCastLayerMask))
        {

            SphereLoc = SphereCastCenterOnCollision(ArbiterRobot.transform.position, target - ArbiterRobot.transform.position, hitInfo.distance);

            degree = ComputeDistance(hitInfo.collider.gameObject.transform.position, ArbiterRobot.transform.position, target);

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

    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(this.ArbiterRobot.transform.forward * 75f, 75f);
    //}
}
