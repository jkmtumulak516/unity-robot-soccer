using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRoutine : MonoBehaviour {

    public int Spin = 0;
    public float SpinTime = 0.5f;

    float TimeCounter = 0; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Spin != 0)
        {
            float h = Mathf.Pow(10, 10) * Spin;
            GetComponent<Rigidbody>().maxAngularVelocity = 7;
            GetComponent<Rigidbody>().AddTorque(transform.up * h, ForceMode.Impulse);
            TimeCounter += Time.deltaTime;
            if(TimeCounter >= SpinTime)
            {
                Spin = 0;
                TimeCounter = 0;
            }
        }
        
        
    }
}
