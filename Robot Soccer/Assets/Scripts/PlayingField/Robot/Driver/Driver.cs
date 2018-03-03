using Assets.Scripts.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver {

    RightWheelFLS RightFls;
    LeftWheelFLS LeftFls;
    RobotCarController Robot;

    private float _left;
    private float _right;

	public Driver(RobotCarController robot)
    {
        Robot = robot;
        RightFls = new RightWheelFLS();
        LeftFls = new LeftWheelFLS();
    }

    public void Process(float destX, float destY)
    {
        var angle = Angle.ComputeRelativeAngle(Robot.transform.eulerAngles.y, Robot.transform.position.x, Robot.transform.position.z, destX, destY);
        var dist = Vector3.Distance(Robot.transform.position, new Vector3(destX, Robot.transform.position.y, destY));

        _left = LeftFls.GetTorque((float)angle, dist);
        _right = RightFls.GetTorque((float)angle, dist);
    }


    public float RightTorque { get { return _right; } }
    public float LeftTorque { get { return _left; } }
}
