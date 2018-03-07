using Assets.Scripts.PlayingField.Robot.Driver;
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
    public GameObject arbiterMarker;

    public TeamController Team;

    public int Spin = 0;
    public float SpinTime = 0.5f;

    float TimeCounter = 0;

    public IDriver Driver;

    public float DestX = 0;
    public float DestY = 0;

    public LayerMask layer;
    float DistanceKeep = 10;

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

        if(Team.Team == TEAM.RED)
            this.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Material/RedTeamMaterial");

        this.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer((Team.Team == TEAM.RED) ? "Red Team" : "Blue Team");


    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Time.timeScale = 4f;
        if (simulationManager.IsStart || simulationManager == null) {
            RaycastHit hit;
            Vector3 tar = new Vector3(DestX, transform.position.y, DestY);
            if (HasCollision(tar, out hit))
            {
                Vector3 t1 = new Vector3();
                Vector3 t2 = new Vector3();

                var m1 = GetSlope(tar, hit.point);
                var m2 = -(1 / m1);

                //horizontal
                if(m1 == 0)
                {
                    t1.z = tar.z;
                    t2.z = tar.z;

                    t1.x = tar.x + DistanceKeep;
                    t2.x = tar.x - DistanceKeep;
                } else if (float.IsInfinity(m1))
                {
                    t1.z = tar.z - DistanceKeep;
                    t2.z = tar.z + DistanceKeep;

                    t1.x = tar.x ;
                    t2.x = tar.x ;
                }else
                {
                    var A = m1;
                    var B = -1;
                    var C = tar.x - m1 * tar.z;

                    t1.z = (((B*m2*tar.z) - (B*tar.x) + (DistanceKeep*Mathf.Sqrt(Mathf.Pow(A,2) + Mathf.Pow(B, 2))) / (B*m2 + A)));
                    t1.x = m2 * (t1.z - tar.z) + t1.x;

                    t2.z = (((B * m2 * tar.z) - (B * tar.x) + (DistanceKeep * Mathf.Sqrt(Mathf.Pow(A, 2) + Mathf.Pow(B, 2))) / (B * m2 + A)));
                    t2.x = m2 * (t2.z - tar.z) + t1.x;
                }

                bool t1Collision = HasCollision(t1);
                bool t2Collision = HasCollision(t2);

                var t1Dist = Vector3.Distance(t1, tar);
                var t2Dist = Vector3.Distance(t2, tar);

                if (t1Collision && !t2Collision)
                {
                    Driver.Process(t2.x, t2.z);
                }else if (!t1Collision && t2Collision)
                {
                    Driver.Process(t1.x, t1.z);
                }
                else
                {
                    var smaller = (t1Dist <= t2Dist) ? t1 : t2;
                    Driver.Process(smaller.x, smaller.z);
                }
            }else
                Driver.Process(DestX, DestY);

            leftMotorTorque = Driver.LeftTorque;
            rightMotorTorque = Driver.RightTorque;

		    float leftMotor = maxMotorTorque * leftMotorTorque;
		    float rightMotor = maxMotorTorque * rightMotorTorque;
		    if (axleInfo.motor) {
			    axleInfo.leftWheel.motorTorque = leftMotor;
			    axleInfo.rightWheel.motorTorque = rightMotor;
		    }

            if (Spin != 0)
            {
                float h = Mathf.Pow(10, 10) * Spin;
                GetComponent<Rigidbody>().maxAngularVelocity = 5;
                GetComponent<Rigidbody>().AddTorque(transform.up * h, ForceMode.Impulse);
                TimeCounter += Time.deltaTime;
                if (TimeCounter >= SpinTime)
                {
                    Spin = 0;
                    TimeCounter = 0;
                }
            }

            //leftWheel.transform.Rotate(0, axleInfo.leftWheel.rpm / 60 * 360 * Time.deltaTime, 0);
            //rightWheel.transform.Rotate(0, axleInfo.rightWheel.rpm / 60 * 360 * Time.deltaTime, 0);
        }

    }

    public void ToggleArbiterMarker(bool active)
    {
        arbiterMarker.SetActive(active);
    }


    bool HasCollision(Vector3 target)
    {
        RaycastHit hitInfo;
        return (Physics.SphereCast(this.transform.position, 10f, target - this.transform.position, out hitInfo, 17f, layer));
        
    }

    bool HasCollision(Vector3 target, out RaycastHit hitInfo)
    {
        return (Physics.SphereCast(this.transform.position, 10f, target - this.transform.position, out hitInfo, 17f, layer));
    }

    float GetSlope(Vector3 a, Vector3 b)
    {
        //x - z
        //y - x
        return (a.x - b.x) / (a.z - b.z);
    }



    [System.Serializable]
	public class AxleInfo {
		public WheelCollider leftWheel;
		public WheelCollider rightWheel;
		public bool motor; // is this wheel attached to motor?
	}
}
