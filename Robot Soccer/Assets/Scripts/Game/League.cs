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
            public class Init
            {
                public static Vector3 GoaliePosition = new Vector3(0, 3, 65.33f);
                public static Vector3 DefenderPosition = new Vector3(0, 3, 48.7f);
                public static Vector3 ForwardPosition = new Vector3(0, 3, 14.04f);

                public static Vector3 Scale = new Vector3(130f, 0.9f, 150f);
                public static int CenterCirleRadius = 20;
            }
            
            
        }

        public class Middle
        {
            public class Init
            {
                public static Vector3 GoaliePosition = new Vector3(0, 3, 95f);
                public static Vector3 DefenderPosition = new Vector3(0, 3, 70f);
                public static Vector3 ForwardPosition = new Vector3(0, 3, 20f);
                public static Vector3[] MidfielderPosition = {
                 new Vector3(40, 2, 50f),
                 new Vector3(-40, 2, 50f),
                };

                public static Vector3 Scale = new Vector3(180f, 0.9f, 220f);
                public static int CenterCirleRadius = 25;

                public static Vector3 TopCameraPosition = new Vector3(-488.0269f, 2.7f, -70.7f);
                public static Vector3 LeftCameraPosition = new Vector3(-487.4268f, -185.4746f, 73f);
                public static Vector3 RightCameraPosition = new Vector3(-487.4268f, -185.4746f, -215.4f);
            }
            
        }

        public class Large
        {

            public class Init
            {
                public static Vector3 GoaliePosition = new Vector3(0, 2, 175f);
                public static Vector3[] DefenderPosition = {
                new Vector3(50, 3, 125f),
                new Vector3(0, 3, 140f),
                new Vector3(-50, 3, 125f),
            };
                public static Vector3[] ForwardPosition = {
                new Vector3(0, 3, 30f),
                new Vector3(50, 3, 30f),
                new Vector3(-50, 3, 30f),
            };
                public static Vector3[] MidfielderPosition = {
                 new Vector3(25, 3, 85f),
                new Vector3(-25, 3, 85f),
                new Vector3(75, 3, 85f),
                new Vector3(-75, 3, 85f),
            };

                public static Vector3 Scale = new Vector3(280f, 0.9f, 400f);
                public static int CenterCirleRadius = 70;

                public static Vector3 TopCameraPosition = new Vector3(-488.0269f, 101.7f, -70.7f);
                public static Vector3 LeftCameraPosition = new Vector3(-487.4268f, -166.8f, 191.3f);
                public static Vector3 RightCameraPosition = new Vector3(-487.4268f, -166.8f, -333.9f);
            }
        }
            
    }
}
