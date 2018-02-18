using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationHolder : MonoBehaviour {
    public Configuration c;
    public bool IsFirstInitialization;
    public int StrategyInitMode; // 0 - default | 1 - random
    public int ActionInitMode; // 0 - default | 1 - random
	// Use this for initialization
	void Start () {
        c = null;
        IsFirstInitialization = false;
        StrategyInitMode = 0;
        ActionInitMode = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SetConfiguration(Configuration c)
    {
        this.c = c;
        Debug.Log("Received Configuration\n" + c.ToString());
    }

    public void SetConfiguration(Configuration c, int Strategy, int Action)
    {
        this.c = c;
        this.StrategyInitMode = Strategy;
        this.ActionInitMode = Action;
        IsFirstInitialization = true;
        Debug.Log("Received Configuration\n" + c.ToString());
        
    }
}
