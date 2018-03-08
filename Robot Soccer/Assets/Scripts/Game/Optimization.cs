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
                //new RobotAndBall(
                //    new Vector3(0f, 1.25f, 15f), 
                //    new Vector3(0f, 1.25f, 0f), 
                //    Quaternion.identity),
                new RobotAndBall(
                    new Vector3(-10f, 1.25f, -30f),
                    new Vector3(30f, 1.25f, -30f),
                    Quaternion.Euler(0f, 90f, 0f)),
                new RobotAndBall(
                    new Vector3(10f, 1.25f, -30f),
                    new Vector3(-30f, 1.25f, -30f),
                    Quaternion.Euler(0f, 270f, 0f)),
                new RobotAndBall(
                    new Vector3(-30f, 1.25f, -20f),
                    new Vector3(-30f, 1.25f, -40f),
                    Quaternion.identity),
                new RobotAndBall(
                    new Vector3(30f, 1.25f, -20f),
                    new Vector3(30f, 1.25f, -40f),
                    Quaternion.identity),
                new RobotAndBall(
                    new Vector3(55f, 1.25f, -5f),
                    new Vector3(40f, 1.25f, -20f),
                    Quaternion.Euler(0f, 315f, 0f)),
                new RobotAndBall(
                    new Vector3(-55f, 1.25f, -5f),
                    new Vector3(-40f, 1.25f, -20f),
                    Quaternion.Euler(0f, 45f, 0f)),
                new RobotAndBall(
                    new Vector3(-30f, 1.25f, 20f),
                    new Vector3(0f, 1.25f, -30f),
                    Quaternion.identity),
                new RobotAndBall(
                    new Vector3(30f, 1.25f, 20f),
                    new Vector3(0f, 1.25f, -30f),
                    Quaternion.identity),
                new RobotAndBall(
                    new Vector3(-20f, 1.25f, -40f),
                    new Vector3(-40f, 1.25f, -50f),
                    Quaternion.Euler(0f, 270f, 0f)),
                new RobotAndBall(
                    new Vector3(20f, 1.25f, -40f),
                    new Vector3(40f, 1.25f, -50f),
                    Quaternion.Euler(0f, 90f, 0f))
            };
        }
    }
}
