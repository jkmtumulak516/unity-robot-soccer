using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TeamController;

public class RobotCarController : MonoBehaviour {
	public AxleInfo axleInfo; 
	public float maxMotorTorque; // maximum torque the motor can apply to wheel
	public float leftMotorTorque;
	public float rightMotorTorque;

    public GameObject leftWheel;
    public GameObject rightWheel;
    
    public TeamController Team;

    public Driver Driver;

    public float DestX = 0;
    public float DestY = 0;

    SimulationManager simulationManager;
	// Use this for initialization
	void Start () {
        simulationManager = GameObject.Find("SimulationManager").GetComponent<SimulationManager>();
        DestX = this.transform.position.x;
        DestY = this.transform.position.z;
        Driver = new Driver(this);
    }

    public void Initialize(TeamController team)
    {
        Team = team;

        if(Team.team == TEAM.RED)
            this.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Material/RedTeamMaterial");

        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (simulationManager.IsStart) { 
            Driver.Process(DestX, DestY);

            leftMotorTorque = Driver.LeftTorque;
            rightMotorTorque = Driver.RightTorque;

		    float leftMotor = maxMotorTorque * leftMotorTorque;
		    float rightMotor = maxMotorTorque * rightMotorTorque;
		    if (axleInfo.motor) {
			    axleInfo.leftWheel.motorTorque = leftMotor;
			    axleInfo.rightWheel.motorTorque = rightMotor;
		    }

                //leftWheel.transform.Rotate(0,axleInfo.leftWheel.rpm / 60 * 360 * Time.deltaTime, 0);
                //rightWheel.transform.Rotate(0,axleInfo.rightWheel.rpm / 60 * 360 * Time.deltaTime, 0);
        }

    }

    

	[System.Serializable]
	public class AxleInfo {
		public WheelCollider leftWheel;
		public WheelCollider rightWheel;
		public bool motor; // is this wheel attached to motor?
	}
}
