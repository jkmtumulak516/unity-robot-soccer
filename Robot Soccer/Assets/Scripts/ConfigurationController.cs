using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class ConfigurationController : MonoBehaviour {

	Vector3 AutoLocalScale;
	Configuration[] ConfigList;
	string SavedConfigsPath;
	DetailsController DetailsCommunicator;

	// Use this for initialization
	void Start () {
		DetailsCommunicator = GameObject.FindGameObjectWithTag ("DetailsPanel").GetComponent<DetailsController> ();
		AutoLocalScale = new Vector3( 1.0f, 1.0f, 1.0f );
		SavedConfigsPath = Directory.GetCurrentDirectory () + "\\Saved";
		string[] configsPath = Directory.GetFiles (SavedConfigsPath, "*.fuz", SearchOption.TopDirectoryOnly);

		ParseConfigs (configsPath);

		foreach (Configuration c in ConfigList) {
			GenerateElement (c);
		}
	}

	/**
	 * Initializes ConfigList and iterates through the configspath then parses it.
	 **/
	private void ParseConfigs(string[] configsPath) {
		ConfigList = new Configuration[configsPath.Length];
		int index = 0;
		foreach (string path in configsPath) {
			ConfigList [index] = Configuration.Parse (path);
			index = index + 1;
		}
	}


	/**
	 *	Generates an ConfigElement(GameObject) using the data in the passed Configuration class
	 **/
	private void GenerateElement(Configuration config) {
		// Instantiates the prefab
		GameObject element = (GameObject)Instantiate(Resources.Load("ConfigElement"));

		element.transform.SetParent (this.transform, false);
		element.transform.localScale = AutoLocalScale;
		element.transform.localPosition = Vector3.zero;

		element.GetComponentInChildren<Text> ().text = config.Title;
	}


	/**
	 * Called by the onSelect listener, passes its index then forwards the corresponding Configuration
	 * to DetailsController for rendering.
	 **/
	public void DetailsTrigger(int index) {
		DetailsCommunicator.FillDetails (ConfigList [index]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
