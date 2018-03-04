using System;
using Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets;
using Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets.XDistances;
using Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets.YDistances.Input;
using Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets.YDistances.Output;
using Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySystems;
using UnityEngine;

public class GoalieController : MonoBehaviour
{
    private GoalieXDistance _goalie_x_distance;
    private GoalieInputYDistance _goalie_y_distance;
    private GoalieXDistance _ball_x_distance;
    private GoalieInputYDistance _ball_y_distance;

    private GoalieStrategizer _strategizer;

    private GoalieStrategy _strategy_1;
    private GoalieStrategy _strategy_2;
    private GoalieStrategy _strategy_3;
    private GoalieStrategy _strategy_4;

    private RobotCarController _robot_controller;
    
    public float FixedX;
    public GameObject Ball;
    public GameObject Goal;
    ConfigurationHolder Config;
    
    void Start ()
    {
        Config = GameObject.Find("ConfigurationHolder").GetComponent<ConfigurationHolder>();

        GoalieOutputYDistance yOutput = null;
        var category = new GoalieCategory(6);

        switch (Config.c.NumberOfRobots)
        {
            case 3:
                _goalie_x_distance = new SmallGoalieXDistance(1);
                _goalie_y_distance = new SmallGoalieInputYDistance(2);
                _ball_x_distance = new SmallGoalieXDistance(3);
                _ball_y_distance = new SmallGoalieInputYDistance(4);
                yOutput = new SmallGoalieOutputYDistance(5);
                break;
            case 5:
                throw new NotImplementedException("Middle League FuzzySets not implemented.");
            case 11:
                throw new NotImplementedException("Large League FuzzySets not implemented.");
            default:
                break;
        }

        _strategizer = new GoalieStrategizer(_ball_x_distance, _goalie_x_distance, category);

        _strategy_1 = new GoalieStrategy(1, _ball_y_distance, _goalie_y_distance, yOutput);
        _strategy_2 = new GoalieStrategy(2, _ball_y_distance, _goalie_y_distance, yOutput);
        _strategy_3 = new GoalieStrategy(3, _ball_y_distance, _goalie_y_distance, yOutput);
        _strategy_4 = new GoalieStrategy(4, _ball_y_distance, _goalie_y_distance, yOutput);

        _robot_controller = GetComponent<RobotCarController>();
    }
	
	void FixedUpdate () {

        float goalX = Goal.transform.position.z;

        int strategyNumber = (int)Math.Round(_strategizer.GetCategory(Math.Abs(goalX - Ball.transform.position.z), Math.Abs(goalX - transform.position.x)));
        float yOutput = 0;

        switch (strategyNumber)
        {
            case 1:
                yOutput = _strategy_1.GetOutput(Ball.transform.position.x, transform.position.x);
                break;
            case 2:
                yOutput = _strategy_2.GetOutput(Ball.transform.position.x, transform.position.x);
                break;
            case 3:
                yOutput = _strategy_3.GetOutput(Ball.transform.position.x, transform.position.x);
                break;
            case 4:
                yOutput = _strategy_4.GetOutput(Ball.transform.position.x, transform.position.x);
                break;
            default: throw new Exception("Invalid Strategy!");
        }

        _robot_controller.DestX = FixedX;
        _robot_controller.DestY = yOutput;
    }
}
