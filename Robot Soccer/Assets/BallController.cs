using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public Collider[] hits;
    public int layer = 9;
    public float radius = 50;
    public GameObject sphere;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        hits = Physics.OverlapSphere(this.transform.forward * radius, radius, 1 << layer);
        sphere.transform.localScale = new Vector3(2*radius, 2 * radius, 2 * radius);
        sphere.transform.position = this.transform.forward * radius;
    }
}
