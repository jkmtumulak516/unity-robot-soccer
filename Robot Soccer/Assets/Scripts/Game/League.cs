using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class League
    {
        public class Small
        {
            public static Vector3[] RobotPositions =  {
                new Vector3(0, 2, 65.33f),
                new Vector3(30.36f, 2, 14.04f),
                new Vector3(0, 2, 48.7f)
            };

            public static Vector3 Scale = new Vector3(130f, 0.9f, 150f);
            public static int CenterCirleRadius = 20;
        }

        public class Middle
        {
            public static Vector3[] RobotPositions = {
                new Vector3(0, 2, 95f),
                new Vector3(0, 2, 20f),
                new Vector3(0, 2, 70f),
                new Vector3(40, 2, 50f),
                new Vector3(-40, 2, 50f),
            };

            public static Vector3 Scale = new Vector3(180f, 0.9f, 220f);
            public static int CenterCirleRadius = 25;
        }

        public class Large
        {
            public static Vector3[] RobotPositions = {
                new Vector3(0, 2, 175f),
                new Vector3(0, 2, 30f),
                new Vector3(50, 2, 30f),
                new Vector3(-50, 2, 30f),
                new Vector3(25, 2, 85f),
                new Vector3(-25, 2, 85f),
                new Vector3(75, 2, 85f),
                new Vector3(-75, 2, 85f),
                new Vector3(50, 2, 125f),
                new Vector3(0, 2, 140f),
                new Vector3(-50, 2, 125f),
            };

            public static Vector3 Scale = new Vector3(280f, 0.9f, 400f);
            public static int CenterCirleRadius = 70;
        }
    }
}
