using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCarController : MonoBehaviour {
	public AxleInfo axleInfo; 
	public float maxMotorTorque; // maximum torque the motor can apply to wheel
	public float leftMotorTorque;
	public float rightMotorTorque;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float leftMotor = maxMotorTorque * leftMotorTorque;
		float rightMotor = maxMotorTorque * rightMotorTorque;
		if (axleInfo.motor) {
			axleInfo.leftWheel.motorTorque = leftMotor;
			axleInfo.rightWheel.motorTorque = rightMotor;
		}
	}

	[System.Serializable]
	public class AxleInfo {
		public WheelCollider leftWheel;
		public WheelCollider rightWheel;
		public bool motor; // is this wheel attached to motor?
	}
}
