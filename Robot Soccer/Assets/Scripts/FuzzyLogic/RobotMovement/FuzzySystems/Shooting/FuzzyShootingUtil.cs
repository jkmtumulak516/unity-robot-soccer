using Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySets;
using FuzzyLogicSystems.Core;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;
using System;
using System.Linq;
using System.Collections.Generic;
using FuzzyLogicSystems.Core.Generic.RuleBase;

namespace Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySystems.Shooting
{
    public static class FuzzyShootingUtil
    {
        private readonly static Random random = new Random();

        public readonly static Distance DistanceSet = new Distance(1);
        public readonly static RelativeAngle RobotBallAngleSet = new RelativeAngle(2);
        public readonly static RelativeAngle GoalBallAngleSet = new RelativeAngle(3);
        public readonly static RelativeAngle RobotGoalAngleSet = new RelativeAngle(4);

        public readonly static List<FuzzySet<IInputFuzzyMember>> InputSets = new List<FuzzySet<IInputFuzzyMember>>()
        {
            DistanceSet,
            RobotBallAngleSet,
            GoalBallAngleSet,
            RobotGoalAngleSet
        };

        public readonly static Torque TorqueSet = new Torque(5);

        public readonly static List<IResultFuzzyMember> TorqueMembers = (from t in TorqueSet.Members select t).ToList();

        public static EvaluationTreeRuleBase CreateRandomEvaluationTreeRuleBase()
        {
            return new EvaluationTreeRuleBase(InputSets, TorqueSet, CreateRandomRules());
        }

        public static List<ParentRule> CreateRandomRules()
        {
            var rules = new List<ParentRule>(DistanceSet.Members.Count * RobotBallAngleSet.Members.Count * GoalBallAngleSet.Members.Count * RobotGoalAngleSet.Members.Count);
            var rb = new RuleBuilder();

            RandomVeryNearRules(rules, rb);
            RandomNearRules(rules, rb);
            RandomMediumRules(rules, rb);
            RandomFarRules(rules, rb);
            RandomVeryFarRules(rules, rb);

            return rules;
        }

        private static void RandomVeryNearRules(List<ParentRule> rules, RuleBuilder rb)
        {
            // VERY NEAR
            {
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryNear).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));
            }
        }

        private static void RandomNearRules(List<ParentRule> rules, RuleBuilder rb)
        {
            // NEAR
            {
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /***************************************************************************/

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /***************************************************************************/

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /***************************************************************************/

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /***************************************************************************/

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /***************************************************************************/

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /***************************************************************************/

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Near).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));
            }
        }

        private static void RandomMediumRules(List<ParentRule> rules, RuleBuilder rb)
        {
            // MEDIUM
            {
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*****************************************************************************/

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*****************************************************************************/

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*****************************************************************************/

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*****************************************************************************/

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*****************************************************************************/

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /*****************************************************************************/

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Medium).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));
            }
        }

        private static void RandomFarRules(List<ParentRule> rules, RuleBuilder rb)
        {
            // FAR
            {
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /****************************Far*******************************************/

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /****************************Far*******************************************/

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /****************************Far*******************************************/

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /****************************Far*******************************************/

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /****************************Far*******************************************/

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /****************************Far*******************************************/

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.Far).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));
            }
        }

        private static void RandomVeryFarRules(List<ParentRule> rules, RuleBuilder rb)
        {
            // VERY FAR
            {
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Left).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyLeft).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Front).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.SlightlyRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.Right).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                /******************************************************************************/

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Left).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyLeft).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Front).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.SlightlyRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.Right).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));

                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Left).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyLeft).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Front).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.SlightlyRight).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.Right).Build(RandomTorque()));
                rules.Add(rb.Var(DistanceSet.VeryFar).And().Var(RobotBallAngleSet.VeryRight).And().Var(GoalBallAngleSet.VeryRight).And().Var(RobotGoalAngleSet.VeryRight).Build(RandomTorque()));
            }
        }

        private static IResultFuzzyMember RandomTorque()
        {
            return TorqueMembers[random.Next(TorqueMembers.Count)];
        }
    }
}
