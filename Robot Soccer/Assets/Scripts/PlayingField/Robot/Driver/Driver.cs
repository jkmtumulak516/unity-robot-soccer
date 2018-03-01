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
        var angle = ComputeRelativeAngle(destX, destY);
        var dist = Vector3.Distance(Robot.transform.position, new Vector3(destX, Robot.transform.position.y, destY));

        _left = LeftFls.GetTorque((float)angle, dist);
        _right = RightFls.GetTorque((float)angle, dist);
    }

    private double ComputeRelativeAngle(float destX, float destY)
    {
        return Normalize(RadianToDegree(Math.Atan2(destX - Robot.transform.position.x, destY - Robot.transform.position.z)) - Robot.transform.eulerAngles.y);
    }

    private double RadianToDegree(double angle)
    {
        return angle * (180.0 / Math.PI);
    }

    private double Normalize(double angle)
    {
        if (angle < -180)
        {
            angle += 360;
        }
        else if (angle > 180)
        {
            angle -= 360;
        }

        return angle;
    }

    public float RightTorque { get { return _right; } }
    public float LeftTorque { get { return _left; } }
}
