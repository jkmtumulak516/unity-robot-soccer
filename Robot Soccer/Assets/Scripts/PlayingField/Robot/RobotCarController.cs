using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCarController : MonoBehaviour {
    public enum TEAM : int { BLUE, RED };
	public AxleInfo axleInfo; 
	public float maxMotorTorque; // maximum torque the motor can apply to wheel
	public float leftMotorTorque;
	public float rightMotorTorque;
    public GameObject leftWheel;
    public GameObject rightWheel;
    public TEAM Team;
	// Use this for initialization
	void Start () {
	}

    public void Initialize(TEAM team)
    {
        Team = team;

        if(team == TEAM.RED)
            this.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Material/RedTeamMaterial");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		float leftMotor = maxMotorTorque * leftMotorTorque;
		float rightMotor = maxMotorTorque * rightMotorTorque;
		if (axleInfo.motor) {
			axleInfo.leftWheel.motorTorque = leftMotor;
			axleInfo.rightWheel.motorTorque = rightMotor;
        }

        leftWheel.transform.Rotate(0, axleInfo.leftWheel.rpm / 60 * 360 * Time.deltaTime, 0);
        rightWheel.transform.Rotate(0, axleInfo.rightWheel.rpm / 60 * 360 * Time.deltaTime, 0);

    }

    

	[System.Serializable]
	public class AxleInfo {
		public WheelCollider leftWheel;
		public WheelCollider rightWheel;
		public bool motor; // is this wheel attached to motor?
	}
}
