using Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySets;
using Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySets.Goalie;
using FuzzyLogicSystems.Core.Generic;
using FuzzyLogicSystems.Core.Generic.Defuzzifier;
using FuzzyLogicSystems.Core.Generic.Fuzzifier;
using FuzzyLogicSystems.Core.Generic.RuleBase;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;
using System.Collections.Generic;

namespace Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySystems
{
    public class GoalieRightWheelFLS
    {
        private readonly GoalieRelativeAngle angle;
        private readonly GoalieDistance distance;
        private readonly Torque torque;
        private FuzzyLogicSystem fls;
        private List<FuzzySet<IInputFuzzyMember>> listInput;

        public GoalieRightWheelFLS()
        {
            angle = new GoalieRelativeAngle(1);
            distance = new GoalieDistance(2);
            torque = new Torque(3);
            listInput = new List<FuzzySet<IInputFuzzyMember>>() { angle, distance };
            var rules = CreateRules();
            var ruleBase = new EvaluationTreeRuleBase(listInput, torque, rules);

            fls = new FuzzyLogicSystem(new Fuzzifier(), new CenterOfSumsDefuzzifier(), ruleBase);
        }

        public List<ParentRule> CreateRules()
        {
            var listOfRules = new List<ParentRule>();
            var builder = new RuleBuilder();

            //Very Left
            listOfRules.Add(builder.Var(angle.VeryLeft).And().Var(distance.VeryNear).Build(torque.SlowBackward));
            listOfRules.Add(builder.Var(angle.VeryLeft).And().Var(distance.Near).Build(torque.Backward));
            listOfRules.Add(builder.Var(angle.VeryLeft).And().Var(distance.Medium).Build(torque.FastBackward));
            listOfRules.Add(builder.Var(angle.VeryLeft).And().Var(distance.Far).Build(torque.FastBackward));
            listOfRules.Add(builder.Var(angle.VeryLeft).And().Var(distance.VeryFar).Build(torque.FastBackward));

            // Mostly Left
            listOfRules.Add(builder.Var(angle.MostlyLeft).And().Var(distance.VeryNear).Build(torque.Backward));
            listOfRules.Add(builder.Var(angle.MostlyLeft).And().Var(distance.Near).Build(torque.FastBackward));
            listOfRules.Add(builder.Var(angle.MostlyLeft).And().Var(distance.Medium).Build(torque.FastBackward));
            listOfRules.Add(builder.Var(angle.MostlyLeft).And().Var(distance.Far).Build(torque.FastBackward));
            listOfRules.Add(builder.Var(angle.MostlyLeft).And().Var(distance.VeryFar).Build(torque.FastBackward));

            //Left
            //listOfRules.Add(builder.Var(angle.Left).And().Var(distance.VeryNear).Build(torque.Forward));
            //listOfRules.Add(builder.Var(angle.Left).And().Var(distance.Near).Build(torque.FastForward));
            //listOfRules.Add(builder.Var(angle.Left).And().Var(distance.Medium).Build(torque.FastForward));
            //listOfRules.Add(builder.Var(angle.Left).And().Var(distance.Far).Build(torque.FastForward));
            //listOfRules.Add(builder.Var(angle.Left).And().Var(distance.VeryFar).Build(torque.FastForward));

            //Slightly Left
            listOfRules.Add(builder.Var(angle.SlightlyLeft).And().Var(distance.VeryNear).Build(torque.Forward));
            listOfRules.Add(builder.Var(angle.SlightlyLeft).And().Var(distance.Near).Build(torque.FastForward));
            listOfRules.Add(builder.Var(angle.SlightlyLeft).And().Var(distance.Medium).Build(torque.FastForward));
            listOfRules.Add(builder.Var(angle.SlightlyLeft).And().Var(distance.Far).Build(torque.FastForward));
            listOfRules.Add(builder.Var(angle.SlightlyLeft).And().Var(distance.VeryFar).Build(torque.FastForward));

            //Front
            listOfRules.Add(builder.Var(angle.Front).And().Var(distance.VeryNear).Build(torque.SlowForward));
            listOfRules.Add(builder.Var(angle.Front).And().Var(distance.Near).Build(torque.Forward));
            listOfRules.Add(builder.Var(angle.Front).And().Var(distance.Medium).Build(torque.FastForward));
            listOfRules.Add(builder.Var(angle.Front).And().Var(distance.Far).Build(torque.FastForward));
            listOfRules.Add(builder.Var(angle.Front).And().Var(distance.VeryFar).Build(torque.FastForward));

            //Slightly Right
            listOfRules.Add(builder.Var(angle.SlightlyRight).And().Var(distance.VeryNear).Build(torque.Stop));
            listOfRules.Add(builder.Var(angle.SlightlyRight).And().Var(distance.Near).Build(torque.SlowForward));
            listOfRules.Add(builder.Var(angle.SlightlyRight).And().Var(distance.Medium).Build(torque.Forward));
            listOfRules.Add(builder.Var(angle.SlightlyRight).And().Var(distance.Far).Build(torque.Forward));
            listOfRules.Add(builder.Var(angle.SlightlyRight).And().Var(distance.VeryFar).Build(torque.FastForward));

            //Right
            //listOfRules.Add(builder.Var(angle.Right).And().Var(distance.VeryNear).Build(torque.Stop));
            //listOfRules.Add(builder.Var(angle.Right).And().Var(distance.Near).Build(torque.Stop));
            //listOfRules.Add(builder.Var(angle.Right).And().Var(distance.Medium).Build(torque.Stop));
            //listOfRules.Add(builder.Var(angle.Right).And().Var(distance.Far).Build(torque.Stop));
            //listOfRules.Add(builder.Var(angle.Right).And().Var(distance.VeryFar).Build(torque.Stop));

            // Mostly Right
            listOfRules.Add(builder.Var(angle.MostlyRight).And().Var(distance.VeryNear).Build(torque.Stop));
            listOfRules.Add(builder.Var(angle.MostlyRight).And().Var(distance.Near).Build(torque.SlowBackward));
            listOfRules.Add(builder.Var(angle.MostlyRight).And().Var(distance.Medium).Build(torque.Backward));
            listOfRules.Add(builder.Var(angle.MostlyRight).And().Var(distance.Far).Build(torque.Backward));
            listOfRules.Add(builder.Var(angle.MostlyRight).And().Var(distance.VeryFar).Build(torque.FastBackward));

            //Very Right
            listOfRules.Add(builder.Var(angle.VeryRight).And().Var(distance.VeryNear).Build(torque.SlowBackward));
            listOfRules.Add(builder.Var(angle.VeryRight).And().Var(distance.Near).Build(torque.Backward));
            listOfRules.Add(builder.Var(angle.VeryRight).And().Var(distance.Medium).Build(torque.FastBackward));
            listOfRules.Add(builder.Var(angle.VeryRight).And().Var(distance.Far).Build(torque.FastBackward));
            listOfRules.Add(builder.Var(angle.VeryRight).And().Var(distance.VeryFar).Build(torque.FastBackward));

            return listOfRules;
        }

        public float GetTorque(float angle, float distance)
        {
            IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> fuzzified;
            IList<FuzzyValue<IResultFuzzyMember>> evaluated;
            var result = fls.Evaluate(new Dictionary<int, float>
            {
                {this.angle.Category, angle },
                {this.distance.Category, distance }
            }, out fuzzified, out evaluated);

            return result;
        }
    }
}
