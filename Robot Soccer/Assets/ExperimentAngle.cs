using Assets.Scripts;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class ExperimentAngle : MonoBehaviour
{
    public GameObject ball;
    LeftWheelFLS leftFLS;
    RightWheelFLS rightFLS;
    RobotCarController controller;
    //X - Z
    //Y - X
    // Use this for initialization
    void Start()
    {
        leftFLS = new LeftWheelFLS();
        rightFLS = new RightWheelFLS();
        controller = this.GetComponent<RobotCarController>();
        Console.Write("Bitchin");

        Time.timeScale = .5f;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        var angle = ComputeRelativeAngle();
        var dist = Vector3.Distance(this.transform.position, ball.transform.position);

        controller.leftMotorTorque = leftFLS.GetTorque((float)angle, dist);
        controller.rightMotorTorque = rightFLS.GetTorque((float)angle, dist);

        ClearConsole();
    }

    public static void ClearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }


    private double ComputeRelativeAngle()
    {
        //return RadianToDegree(Math.Atan2(ball.transform.position.x , ball.transform.position.z ) - Math.Atan2(this.transform.position.x, this.transform.position.z));
        return Normalize(RadianToDegree(Math.Atan2(ball.transform.position.x - this.transform.position.x, ball.transform.position.z - this.transform.position.z)) - this.transform.eulerAngles.y);
    }

    private double DegreeToRadian(double angle)
    {
        return Math.PI * angle / 180.0;
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

    public class RelativeAngle : FuzzySet<IInputFuzzyMember>
    {
        public RelativeAngle(int category) : base(category)
        {
        }

        private IInputFuzzyMember _very_right;
        private IInputFuzzyMember _right;
        private IInputFuzzyMember _slightly_right;
        private IInputFuzzyMember _front;
        private IInputFuzzyMember _slightly_left;
        private IInputFuzzyMember _left;
        private IInputFuzzyMember _very_left;

        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            List<IInputFuzzyMember> collection = new List<IInputFuzzyMember>();

            _very_left = new LinearInput("Very Left", this, -180, true, false, 50, 0);
            collection.Add(_very_left);

            _left = new LinearInput("Left", this, -90, false, false, 50, 0);
            collection.Add(_left);

            _slightly_left = new LinearInput("Slightly Left", this, -45, false, false, 50, 0);
            collection.Add(_slightly_left);

            _front = new LinearInput("Front", this, 0, false, false, 50, 0);
            collection.Add(_front);

            _slightly_right = new LinearInput("Slightly Right", this, 45, false, false, 50, 0);
            collection.Add(_slightly_right);

            _right = new LinearInput("Right", this, 90, false, false, 50, 0);
            collection.Add(_right);

            _very_right = new LinearInput("Very right", this, 180, false, true, 50, 20);
            collection.Add(_very_right);


            return collection;
        }

        public IInputFuzzyMember VeryLeft { get { return _very_left; } }
        public IInputFuzzyMember Left { get {return _left; } }
        public IInputFuzzyMember SlightlyLeft { get { return _slightly_left; } }
        public IInputFuzzyMember Front { get { return _front; } }
        public IInputFuzzyMember SlightlyRight { get { return _slightly_right; } }
        public IInputFuzzyMember Right { get { return _right; } }
        public IInputFuzzyMember VeryRight { get { return _very_right; } }

    }

    public class Distance : FuzzySet<IInputFuzzyMember>
    {
        public Distance(int category) : base(category)
        {
        }

        private IInputFuzzyMember _very_near;
        private IInputFuzzyMember _near;
        private IInputFuzzyMember _medium;
        private IInputFuzzyMember _far;
        private IInputFuzzyMember _very_far;



        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            List<IInputFuzzyMember> collection = new List<IInputFuzzyMember>();

            _very_near = new LinearInput("Very Near", this, 0, true, false, 25, 0);
            collection.Add(_very_near);

            _near = new LinearInput("Near", this, 35, false, false, 25, 0);
            collection.Add(_near);

            _medium = new LinearInput("Medium", this, 70, false, false, 25, 0);
            collection.Add(_medium);

            _far = new LinearInput("Far", this, 105, false, false, 25, 0);
            collection.Add(_far);

            _very_far = new LinearInput("Very far", this, 140, false, true, 25, 0);
            collection.Add(_very_far);

            return collection;

        }

        public IInputFuzzyMember VeryNear { get { return _very_near; } }
        public IInputFuzzyMember Near { get { return _near; } }
        public IInputFuzzyMember Medium { get { return _medium; } }
        public IInputFuzzyMember Far { get { return _far; } }
        public IInputFuzzyMember VeryFar { get { return _very_far; } }
    }

    public class Torque : FuzzySet<IResultFuzzyMember>
    {
        public Torque(int category) : base(category)
        {
        }

        private IResultFuzzyMember _fast_backward;
        private IResultFuzzyMember _backward;
        private IResultFuzzyMember _slow_backward;
        private IResultFuzzyMember _stop;
        private IResultFuzzyMember _slow_forward;
        private IResultFuzzyMember _forward;
        private IResultFuzzyMember _fast_forward;

        protected override ICollection<IResultFuzzyMember> InitializeMembers()
        {
            List<IResultFuzzyMember> collection = new List<IResultFuzzyMember>();

            _fast_backward = new LinearResult("Fast Backward", this, -150, 40, 0);
            collection.Add(_fast_backward);

            _backward = new LinearResult("Backward", this, -100, 40, 0);
            collection.Add(_backward);

            _slow_backward = new LinearResult("Fast Backward", this, -50, 40, 0);
            collection.Add(_slow_backward);

            _stop = new LinearResult("Stop", this, 0, 40, 0);
            collection.Add(_fast_backward);

            _slow_forward = new LinearResult("Slow Forward", this, 50, 40, 0);
            collection.Add(_slow_forward);

            _forward = new LinearResult("Forward", this, 100, 40, 0);
            collection.Add(_forward);

            _fast_forward = new LinearResult("Fast Forward", this, 150, 40, 0);
            collection.Add(_fast_forward);


            return collection;
        }

        public IResultFuzzyMember FastBackward { get { return _fast_backward; } }
        public IResultFuzzyMember Backward { get { return _backward; } }
        public IResultFuzzyMember SlowBackward { get { return _slow_backward; } }
        public IResultFuzzyMember Stop { get { return _stop; } }
        public IResultFuzzyMember SlowForward { get { return _slow_forward; } }
        public IResultFuzzyMember Forward { get { return _forward; } }
        public IResultFuzzyMember FastForward { get { return _fast_forward; } }

    }
}
