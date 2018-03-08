using Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySystems.Shooting;
using Assets.Scripts.Helper;
using FuzzyLogicSystems.Core;
using System;

namespace Assets.Scripts.PlayingField.Robot.Driver
{
    public class ShootingDriver
    {
        ShootingLeftWheelFLS LeftFLS;
        ShootingRightWheelFLS RightFLS;
        RobotCarController Robot;

        private float _left;
        private float _right;

        public ShootingDriver(IFuzzyRuleBase left, IFuzzyRuleBase right)
        {
            LeftFLS = new ShootingLeftWheelFLS(left);
            RightFLS = new ShootingRightWheelFLS(right);
        }

        public void Process(float robotX, float robotY, float robotRotation, float ballX, float ballY, float goalX, float goalY, float goalRotation)
        {
            float robotBallAngle = (float)Angle.ComputeRelativeAngle(robotRotation, robotX, robotY, ballX, ballY);
            float goalBallAngle = (float)Angle.ComputeRelativeAngle(goalRotation, goalX, goalY, ballX, ballY);
            float robotGoalAngle = (float)Angle.ComputeRelativeAngle(robotRotation, robotX, robotY, goalX, goalY);
            float distance = (float)Math.Sqrt(Math.Pow(robotX - ballX, 2) + Math.Pow(robotY - ballY, 2));

            _left = LeftFLS.GetTorque(robotBallAngle, goalBallAngle, robotGoalAngle, distance);
            _right = RightFLS.GetTorque(robotBallAngle, goalBallAngle, robotGoalAngle, distance);
        }

        public float RightTorque { get { return _right; } }
        public float LeftTorque { get { return _left; } }
    }
}
