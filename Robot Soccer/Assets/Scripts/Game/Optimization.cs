using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public static class Optimization
    {
        public static class Shoot
        {
            public class RobotAndBall
            {
                public Vector3 RobotPosition { get; private set; }
                public Vector3 BallPosition { get; private set; }
                public Quaternion RobotRotation { get; private set; }

                public RobotAndBall(Vector3 RobotPosition, Vector3 BallPosition, Quaternion RobotRotation)
                {
                    this.RobotPosition = RobotPosition;
                    this.BallPosition = BallPosition;
                    this.RobotRotation = RobotRotation;
                }
            }

            public static RobotAndBall[] Positions = new RobotAndBall[]
            {
                new RobotAndBall(
                    new Vector3(0f, 2.8f, 8f), 
                    new Vector3(0f, 2.8f, 0f), 
                    Quaternion.identity),
                new RobotAndBall(
                    new Vector3(-15f, 2.8f, -30f),
                    new Vector3(15f, 2.8f, -30f),
                    Quaternion.Euler(0f, 90f, 0f)),
                new RobotAndBall(
                    new Vector3(15f, 2.8f, -30f),
                    new Vector3(-15f, 2.8f, -30f),
                    Quaternion.Euler(0f, 270f, 0f)),
                new RobotAndBall(
                    new Vector3(-30f, 2.8f, -20f),
                    new Vector3(-30f, 2.8f, -40f),
                    Quaternion.identity),
                new RobotAndBall(
                    new Vector3(30f, 2.8f, -20f),
                    new Vector3(30f, 2.8f, -40f),
                    Quaternion.identity),
            };
        }
    }
}
