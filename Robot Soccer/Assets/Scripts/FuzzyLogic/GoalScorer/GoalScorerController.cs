﻿using System;
using Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets;
using Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets.XDistances;
using Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets.YDistances;
using Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySystems;
using UnityEngine;
using UnityEngine.UI;

public class GoalScorerController : MonoBehaviour
{    
    private GoalScorer _scorer;
    public SimulationManager _sim;
    public float Output;

    public Text _score_text;
    int score = 0;
    public GameObject Ball;

    bool IsOptimizationMode = false;
    // Use this for initialization
    void Start ()
    {
        int NumberOfRobots = GameObject.Find("ConfigurationHolder")?.GetComponent<ConfigurationHolder>()?.c?.NumberOfRobots ?? 3;
        if(GameObject.Find("ConfigurationHolder")?.GetComponent<ConfigurationHolder>() == null)
        {
            IsOptimizationMode = true;
        }
        GoalXDistance xDistance;
        GoalYDistance yDistance;
        var consequence = new GoalConsequence(3);

        switch (NumberOfRobots)
        {
            case 3:
                xDistance = new SmallGoalXDistance(1);
                yDistance = new SmallGoalYDistance(2);
                break;
            case 5:
                xDistance = new MiddleGoalXDistance(1);
                yDistance = new MiddleGoalYDistance(2);
                break;
            case 11:
                xDistance = new LargeGoalXDistance(1);
                yDistance = new LargeGoalYDistance(2);
                break;
            default:
                xDistance = new SmallGoalXDistance(1);
                yDistance = new SmallGoalYDistance(2);
                break;
        }
        
        _scorer = new GoalScorer(xDistance, yDistance, consequence);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float ballX = Ball.transform.position.z;
        float ballY = Ball.transform.position.x;
        float goalX = transform.position.z;

        float inputX = Math.Abs(goalX - ballX);
        float inputY = ballY;

        // output whether the ball scored or not
        Output = _scorer.GetConsequence(inputX, inputY);

        if(Output >= 85 && !IsOptimizationMode)
        {
            _score_text.text = ++score + "";
            _sim.ResetSimulation();
        }
	}
}
