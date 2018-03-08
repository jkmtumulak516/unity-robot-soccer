using Assets.Scripts.Game;
using FuzzyLogicSystems.Core;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Game.Optimization.Shoot;
using FuzzyLogicSystems.Core.Generic.RuleBase;

public class TrialController : MonoBehaviour
{
    // -1 - Trial dead
    // 0 - Trial finished
    // 1 - Trial is running
    public int TrialActive;

    public bool IsGoaled;
    public bool IsTimedOut;

    private float ElapsedTime;
    public float TimeLimit;
    public float GoalThreshold;

    public GameObject Robot;
    public GameObject Ball;
    public GameObject Goal;
    public GameObject Optimizer;

    private Rigidbody RobotRigidbody;
    private Rigidbody BallRigidbody;

    private EvaluationTreeRuleBase left;
    private EvaluationTreeRuleBase right;

    private ShootingController ShootingController;
    private GoalScorerController GoalScorer;
    private OptimizationManager OptimizationManager;
    private int PositionCounter;

    private List<float> FitnessList;
    private float CurrentMaxFitness;

	void Start ()
    {
        TrialActive = -1;

        IsGoaled = false;
        IsTimedOut = false;
        ElapsedTime = 0f;

        CurrentMaxFitness = 0f;
        FitnessList = new List<float>(Positions.Length);

        OptimizationManager = Optimizer.GetComponent<OptimizationManager>();
        PositionCounter = 0;

        GoalScorer = Goal.GetComponent<GoalScorerController>();

        Robot = (GameObject)Instantiate(Resources.Load("ShootingCar"), new Vector3(0f, 3f, 15f), Quaternion.identity);
        ShootingController = Robot.GetComponent<ShootingController>();
        ShootingController.Initialize(Ball, Goal);

        RobotRigidbody = Robot.GetComponent<Rigidbody>();
        BallRigidbody = Ball.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (TrialActive == 1 && !IsGoaled && !IsTimedOut)
            RunTrial();

        else if(TrialActive == 1)
            PostTrial();
    }

    public void StartTrial(EvaluationTreeRuleBase leftRuleBase, EvaluationTreeRuleBase rightRuleBase)
    {
        Debug.Log("Start Trial");

        ShootingController.SetDriver(leftRuleBase, rightRuleBase);
        left = leftRuleBase;
        right = rightRuleBase;
        PositionCounter = 0;

        PreTrial();
    }
    
    private void RunTrial()
    {
        Debug.Log("Run Trial");

        ElapsedTime += Time.fixedDeltaTime;

        // handles transition to PostTrial
        IsTimedOut = ElapsedTime >= TimeLimit;
        IsGoaled = GoalScorer.Output >= GoalThreshold;

        CurrentMaxFitness = MeasureCurrentFitness(GoalScorer.Output, CurrentMaxFitness);
    }

    private void PreTrial()
    {
        Debug.Log("Pre Trial");
        // handles transition to RunTrial
        TrialActive = 1;
        ElapsedTime = 0f;
        IsGoaled = false;
        IsTimedOut = false;

        ShootingController.BallHit = false;
        
        var robotAndBall = Positions[PositionCounter++];

        Robot.transform.position = robotAndBall.RobotPosition;
        Robot.transform.rotation = robotAndBall.RobotRotation;
        Ball.transform.position = robotAndBall.BallPosition;

        RobotRigidbody.velocity = Vector3.zero;
        RobotRigidbody.angularVelocity = Vector3.zero;
        BallRigidbody.velocity = Vector3.zero;
        BallRigidbody.angularVelocity = Vector3.zero;
    }

    private void PostTrial()
    {
        Debug.Log("Post Trial");

        if (PositionCounter < Positions.Length)
        {
            FitnessList.Add(ProcessFitness(IsGoaled, ElapsedTime, MeasureCurrentFitness(GoalScorer.Output, CurrentMaxFitness), ShootingController.BallHit));
            PreTrial();
        }

        else
            EndTrials();
    }

    public void EndTrials()
    {
        Debug.Log("End Trial");
        TrialActive = 0;
        float finalFitnesss = AnalyzeFitnessValues(FitnessList);

        left.Fitness = finalFitnesss;
        right.Fitness = finalFitnesss;

        FitnessList.Clear();
        FitnessList.Capacity = Positions.Length;

        OptimizationManager.TrialFinished(left, right);
    }

    private float MeasureCurrentFitness(float goalOutput, float max)
    {
        return goalOutput > max ? goalOutput : max;
    }

    private float ProcessFitness(bool goaled, float elapsedTime, float fitness, bool ballHit)
    {
        float finalFitness;

        if (goaled)
            finalFitness = 0.5f + (elapsedTime / (TimeLimit * 2f));
        else
            finalFitness = fitness / 200f;

        if (!ballHit)
            finalFitness /= 4f;

        return finalFitness;   
    }

    private float AnalyzeFitnessValues(List<float> values)
    {
        return values.Average();
    }
}
