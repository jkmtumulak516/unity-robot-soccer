using Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySystems;
using Assets.Scripts.Helper;
using UnityEngine;

namespace Assets.Scripts.PlayingField.Robot.Driver
{
    public class GoalieDriver : IDriver
    {
        GoalieRightWheelFLS RightFls;
        GoalieLeftWheelFLS LeftFls;
        RobotCarController Robot;

        private float _left;
        private float _right;

        public GoalieDriver(RobotCarController robot)
        {
            Robot = robot;
            RightFls = new GoalieRightWheelFLS();
            LeftFls = new GoalieLeftWheelFLS();
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
}
