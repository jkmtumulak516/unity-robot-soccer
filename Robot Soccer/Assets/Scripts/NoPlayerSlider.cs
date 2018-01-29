using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoPlayerSlider : MonoBehaviour {

	// Use this for initialization
	public Text DisplayText;
	void Start () {
		this.GetComponent<Slider> ().onValueChanged.AddListener(delegate {ValueChanged(); });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ValueChanged() {
		DisplayText.text = this.GetComponent<Slider> ().value.ToString();
	}
}
