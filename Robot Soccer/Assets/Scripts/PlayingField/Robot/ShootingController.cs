using Assets.Scripts.PlayingField.Robot.Driver;
using FuzzyLogicSystems.Core;
using UnityEngine;

public class ShootingController : MonoBehaviour {

    public AxleInfo axleInfo;
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float leftMotorTorque;
    public float rightMotorTorque;

    public bool BallHit;

    public GameObject leftWheel;
    public GameObject rightWheel;
    public GameObject arbiterMarker;

    public GameObject Ball;
    public GameObject Goal;

    public ShootingDriver Driver;

    SimulationManager simulationManager;
    // Use this for initialization
    void Start()
    {
        Driver = null;

        BallHit = false;
    }

    public void Initialize(GameObject ball, GameObject goal) // pass rulebase
    {
        Ball = ball;
        Goal = goal;
    }

    public void SetDriver(IFuzzyRuleBase leftRuleBase, IFuzzyRuleBase rightRuleBase)
    {
        Driver = new ShootingDriver(leftRuleBase, rightRuleBase);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Driver != null)
        {
            Driver.Process(
                transform.position.z, transform.position.x, transform.rotation.eulerAngles.y,
                Ball.transform.position.z, Ball.transform.position.x,
                Goal.transform.position.z, Goal.transform.position.x, Goal.transform.rotation.eulerAngles.y);

            leftMotorTorque = Driver.LeftTorque;
            rightMotorTorque = Driver.RightTorque;

            float leftMotor = maxMotorTorque * leftMotorTorque;
            float rightMotor = maxMotorTorque * rightMotorTorque;

            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = leftMotor;
                axleInfo.rightWheel.motorTorque = rightMotor;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(Ball))
            BallHit = true;
    }

    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor; // is this wheel attached to motor?
    }
}
