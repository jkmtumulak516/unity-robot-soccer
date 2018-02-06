using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActionPanelController : MonoBehaviour {

	public Button CreateButton;
	public Button LoadButton;
	public Button OptimizeButton;
	// Use this for initialization
	void Start () {
		CreateButton.onClick.AddListener (delegate {CreateOnClick(); });
        LoadButton.onClick.AddListener(delegate { PlayingFieldOnClick();  });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangedScene(string SceneName) {
		SceneManager.LoadScene(SceneName);
	}

	void CreateOnClick() {
		ChangedScene ("CreateSimulationMenu");
	}

    void PlayingFieldOnClick()
    {
        ChangedScene("PlayingField");
    }
}
