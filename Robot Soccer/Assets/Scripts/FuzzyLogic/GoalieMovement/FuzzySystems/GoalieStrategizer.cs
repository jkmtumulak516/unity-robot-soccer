using System.Collections.Generic;
using Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets;
using FuzzyLogicSystems.Core;
using FuzzyLogicSystems.Core.Generic;
using FuzzyLogicSystems.Core.Generic.Defuzzifier;
using FuzzyLogicSystems.Core.Generic.Fuzzifier;
using FuzzyLogicSystems.Core.Generic.RuleBase;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;

namespace Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySystems
{
    public class GoalieStrategizer
    {
        private readonly GoalieXDistance _ball_distance;
        private readonly GoalieXDistance _goalie_distance;
        private readonly GoalieCategory _category;

        private readonly IFuzzyRuleBase _rule_base;
        private readonly IFuzzyLogicSystem _fls;

        public GoalieStrategizer(GoalieXDistance ballDistance, GoalieXDistance goalieDistance, GoalieCategory category)
        {
            _ball_distance = ballDistance;
            _goalie_distance = goalieDistance;
            _category = category;
            
            _rule_base = new EvaluationTreeRuleBase(
                new List<FuzzySet<IInputFuzzyMember>>() { _ball_distance, _goalie_distance },
                category, CreateRules());

            _fls = new FuzzyLogicSystem(new Fuzzifier(), new CenterOfSumsDefuzzifier(), _rule_base);
        }

        private GoalieXDistance BallDistance { get { return _ball_distance; } }
        private GoalieXDistance GoalieDistance { get { return _goalie_distance; } }
        private GoalieCategory Category { get { return _category; } }

        private IFuzzyRuleBase RuleBase { get { return _rule_base; } }
        private IFuzzyLogicSystem FuzzyLogicSystem { get { return _fls; } }

        // both parameters are relative to the goal
        public float GetCategory(float ballX, float goalieX)
        {
            var input = new Dictionary<int, float>()
            {
                { BallDistance.Category, ballX },
                { GoalieDistance.Category, goalieX }
            };

            IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> fuzzified;
            IList<FuzzyValue<IResultFuzzyMember>> resultMembers;

            float output = FuzzyLogicSystem.Evaluate(input, out fuzzified, out resultMembers);

            return output;
        }

        private List<ParentRule> CreateRules()
        {
            var rules = new List<ParentRule>(BallDistance.Members.Count * GoalieDistance.Members.Count);
            var rb = new RuleBuilder();

            // Ball Inside
            rules.Add(rb.Var(BallDistance.Inside).And().Var(GoalieDistance.Inside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.Inside).And().Var(GoalieDistance.SlightlyInside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.Inside).And().Var(GoalieDistance.OnGoalLine).Build(Category.One));
            rules.Add(rb.Var(BallDistance.Inside).And().Var(GoalieDistance.SlightlyOutside).Build(Category.Three));
            rules.Add(rb.Var(BallDistance.Inside).And().Var(GoalieDistance.ModeratelyOutside).Build(Category.Two));
            rules.Add(rb.Var(BallDistance.Inside).And().Var(GoalieDistance.FarOutside).Build(Category.Two));
            rules.Add(rb.Var(BallDistance.Inside).And().Var(GoalieDistance.VeryFarOutside).Build(Category.Two));

            // Ball Slightly Inside
            rules.Add(rb.Var(BallDistance.SlightlyInside).And().Var(GoalieDistance.Inside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.SlightlyInside).And().Var(GoalieDistance.SlightlyInside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.SlightlyInside).And().Var(GoalieDistance.OnGoalLine).Build(Category.One));
            rules.Add(rb.Var(BallDistance.SlightlyInside).And().Var(GoalieDistance.SlightlyOutside).Build(Category.Three));
            rules.Add(rb.Var(BallDistance.SlightlyInside).And().Var(GoalieDistance.ModeratelyOutside).Build(Category.Two));
            rules.Add(rb.Var(BallDistance.SlightlyInside).And().Var(GoalieDistance.FarOutside).Build(Category.Two));
            rules.Add(rb.Var(BallDistance.SlightlyInside).And().Var(GoalieDistance.VeryFarOutside).Build(Category.Two));

            // Ball On Goal Line
            rules.Add(rb.Var(BallDistance.OnGoalLine).And().Var(GoalieDistance.Inside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.OnGoalLine).And().Var(GoalieDistance.SlightlyInside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.OnGoalLine).And().Var(GoalieDistance.OnGoalLine).Build(Category.One));
            rules.Add(rb.Var(BallDistance.OnGoalLine).And().Var(GoalieDistance.SlightlyOutside).Build(Category.Three));
            rules.Add(rb.Var(BallDistance.OnGoalLine).And().Var(GoalieDistance.ModeratelyOutside).Build(Category.Two));
            rules.Add(rb.Var(BallDistance.OnGoalLine).And().Var(GoalieDistance.FarOutside).Build(Category.Two));
            rules.Add(rb.Var(BallDistance.OnGoalLine).And().Var(GoalieDistance.VeryFarOutside).Build(Category.Two));

            // Ball Slightly Outside
            rules.Add(rb.Var(BallDistance.SlightlyOutside).And().Var(GoalieDistance.Inside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.SlightlyOutside).And().Var(GoalieDistance.SlightlyInside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.SlightlyOutside).And().Var(GoalieDistance.OnGoalLine).Build(Category.One));
            rules.Add(rb.Var(BallDistance.SlightlyOutside).And().Var(GoalieDistance.SlightlyOutside).Build(Category.Three));
            rules.Add(rb.Var(BallDistance.SlightlyOutside).And().Var(GoalieDistance.ModeratelyOutside).Build(Category.Two));
            rules.Add(rb.Var(BallDistance.SlightlyOutside).And().Var(GoalieDistance.FarOutside).Build(Category.Two));
            rules.Add(rb.Var(BallDistance.SlightlyOutside).And().Var(GoalieDistance.VeryFarOutside).Build(Category.Two));

            // Ball Moderately Outside
            rules.Add(rb.Var(BallDistance.ModeratelyOutside).And().Var(GoalieDistance.Inside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.ModeratelyOutside).And().Var(GoalieDistance.SlightlyInside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.ModeratelyOutside).And().Var(GoalieDistance.OnGoalLine).Build(Category.One));
            rules.Add(rb.Var(BallDistance.ModeratelyOutside).And().Var(GoalieDistance.SlightlyOutside).Build(Category.Four));
            rules.Add(rb.Var(BallDistance.ModeratelyOutside).And().Var(GoalieDistance.ModeratelyOutside).Build(Category.Four));
            rules.Add(rb.Var(BallDistance.ModeratelyOutside).And().Var(GoalieDistance.FarOutside).Build(Category.Two));
            rules.Add(rb.Var(BallDistance.ModeratelyOutside).And().Var(GoalieDistance.VeryFarOutside).Build(Category.Two));

            // Ball Far Outside
            rules.Add(rb.Var(BallDistance.FarOutside).And().Var(GoalieDistance.Inside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.FarOutside).And().Var(GoalieDistance.SlightlyInside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.FarOutside).And().Var(GoalieDistance.OnGoalLine).Build(Category.One));
            rules.Add(rb.Var(BallDistance.FarOutside).And().Var(GoalieDistance.SlightlyOutside).Build(Category.Four));
            rules.Add(rb.Var(BallDistance.FarOutside).And().Var(GoalieDistance.ModeratelyOutside).Build(Category.Four));
            rules.Add(rb.Var(BallDistance.FarOutside).And().Var(GoalieDistance.FarOutside).Build(Category.Four));
            rules.Add(rb.Var(BallDistance.FarOutside).And().Var(GoalieDistance.VeryFarOutside).Build(Category.Two));

            // Ball Very Far Outside
            rules.Add(rb.Var(BallDistance.VeryFarOutside).And().Var(GoalieDistance.Inside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.VeryFarOutside).And().Var(GoalieDistance.SlightlyInside).Build(Category.One));
            rules.Add(rb.Var(BallDistance.VeryFarOutside).And().Var(GoalieDistance.OnGoalLine).Build(Category.One));
            rules.Add(rb.Var(BallDistance.VeryFarOutside).And().Var(GoalieDistance.SlightlyOutside).Build(Category.Four));
            rules.Add(rb.Var(BallDistance.VeryFarOutside).And().Var(GoalieDistance.ModeratelyOutside).Build(Category.Four));
            rules.Add(rb.Var(BallDistance.VeryFarOutside).And().Var(GoalieDistance.FarOutside).Build(Category.Four));
            rules.Add(rb.Var(BallDistance.VeryFarOutside).And().Var(GoalieDistance.VeryFarOutside).Build(Category.Two));

            return rules;
        }
    }
}
