using System;
using Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets;
using Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets.XDistances;
using Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets.YDistances;
using Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySystems;
using UnityEngine;

public class GoalScorerController : MonoBehaviour
{    
    private GoalScorer _scorer;

    public float Output;

    public GameObject Ball;
    ConfigurationHolder Config;
    // Use this for initialization
    void Start ()
    {
        Config = GameObject.Find("ConfigurationHolder").GetComponent<ConfigurationHolder>();

        GoalXDistance xDistance;
        GoalYDistance yDistance;
        var consequence = new GoalConsequence(3);

        switch (Config.c.NumberOfRobots)
        {
            case 3:
                xDistance = new SmallXDistance(1);
                yDistance = new SmallYDistance(2);
                break;
            case 5:
                xDistance = new MiddleXDistance(1);
                yDistance = new MiddleYDistance(2);
                break;
            case 11:
                xDistance = new LargeXDistance(1);
                yDistance = new LargeYDistance(2);
                break;
            default:
                xDistance = new SmallXDistance(1);
                yDistance = new SmallYDistance(2);
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
	}
}
