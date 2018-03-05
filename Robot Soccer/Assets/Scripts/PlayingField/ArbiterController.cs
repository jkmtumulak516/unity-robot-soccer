using Assets.Scripts.FuzzyLogic.Arbiter.FuzzySystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbiterController : MonoBehaviour {

    private ArbiterFLS ArbiterFls;
    public RobotCarController ArbiterRobot;
    public GameObject Ball;
	// Use this for initialization
	void Start () {
        this.ArbiterFls = new ArbiterFLS();

	}
	
	// Update is called once per frame
	void Update () {
        if(ArbiterRobot != null)
        {
            //stuff
        }
	}
}
