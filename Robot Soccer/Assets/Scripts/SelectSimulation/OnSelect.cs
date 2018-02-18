using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSelect : MonoBehaviour {

	// Use this for initialization
	ConfigurationController ConfigController;

	void Start () {
		ConfigController = this.transform.parent.GetComponent<ConfigurationController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Select() {
		Button[] b = this.transform.parent.GetComponentsInChildren<Button> (true);
		foreach (Button bt in b) {
			bt.interactable = true;
		}
		this.GetComponent<Button> ().interactable = false;
		ConfigController.DetailsTrigger (this.transform.GetSiblingIndex ());
	}
}
