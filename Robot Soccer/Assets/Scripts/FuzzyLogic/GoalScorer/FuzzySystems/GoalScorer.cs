using System.Collections.Generic;
using Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets;
using FuzzyLogicSystems.Core;
using FuzzyLogicSystems.Core.Generic;
using FuzzyLogicSystems.Core.Generic.Defuzzifier;
using FuzzyLogicSystems.Core.Generic.Fuzzifier;
using FuzzyLogicSystems.Core.Generic.RuleBase;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;

namespace Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySystems
{
    public class GoalScorer
    {
        private readonly GoalXDistance _x_distance;
        private readonly GoalYDistance _y_distance;
        private readonly GoalConsequence _consequence;

        private readonly IFuzzyRuleBase _rule_base;
        private readonly IFuzzyLogicSystem _fls;

        public GoalScorer(GoalXDistance xDistance, GoalYDistance yDistance,  GoalConsequence consequence)
        {
            _x_distance = xDistance;
            _y_distance = yDistance;
            _consequence = consequence;

            _rule_base = new EvaluationTreeRuleBase(
                new List<FuzzySet<IInputFuzzyMember>>() { _x_distance, _y_distance },
                Consequence, CreateRules());

            _fls = new FuzzyLogicSystem(new Fuzzifier(), new CenterOfSumsDefuzzifier(), _rule_base);
        }

        private GoalXDistance XDistance { get { return _x_distance; } }
        private GoalYDistance YDistance { get { return _y_distance; } }
        private GoalConsequence Consequence { get { return _consequence; } }

        private IFuzzyRuleBase RuleBase { get { return _rule_base; } }
        private IFuzzyLogicSystem FuzzyLogicSystem { get { return _fls; } }

        private List<ParentRule> CreateRules()
        {
            var rules = new List<ParentRule>(XDistance.Members.Count * YDistance.Members.Count);
            var rb = new RuleBuilder();

            // Inside
            rules.Add(rb.Var(XDistance.Inside).And().Var(YDistance.Lower).Build(Consequence.VeryGood));
            rules.Add(rb.Var(XDistance.Inside).And().Var(YDistance.NearLower).Build(Consequence.VeryGood));
            rules.Add(rb.Var(XDistance.Inside).And().Var(YDistance.Center).Build(Consequence.VeryGood));
            rules.Add(rb.Var(XDistance.Inside).And().Var(YDistance.NearUpper).Build(Consequence.VeryGood));
            rules.Add(rb.Var(XDistance.Inside).And().Var(YDistance.Upper).Build(Consequence.VeryGood));

            // Close
            rules.Add(rb.Var(XDistance.Close).And().Var(YDistance.Lower).Build(Consequence.NeedsImprovement));
            rules.Add(rb.Var(XDistance.Close).And().Var(YDistance.NearLower).Build(Consequence.Average));
            rules.Add(rb.Var(XDistance.Close).And().Var(YDistance.Center).Build(Consequence.Satisfactory));
            rules.Add(rb.Var(XDistance.Close).And().Var(YDistance.NearUpper).Build(Consequence.Average));
            rules.Add(rb.Var(XDistance.Close).And().Var(YDistance.Upper).Build(Consequence.NeedsImprovement));

            // Far
            rules.Add(rb.Var(XDistance.Far).And().Var(YDistance.Lower).Build(Consequence.Poor));
            rules.Add(rb.Var(XDistance.Far).And().Var(YDistance.NearLower).Build(Consequence.NeedsImprovement));
            rules.Add(rb.Var(XDistance.Far).And().Var(YDistance.Center).Build(Consequence.Average));
            rules.Add(rb.Var(XDistance.Far).And().Var(YDistance.NearUpper).Build(Consequence.NeedsImprovement));
            rules.Add(rb.Var(XDistance.Far).And().Var(YDistance.Upper).Build(Consequence.Poor));

            return rules;
        }

        public float GetConsequence(float x, float y)
        {
            var input = new Dictionary<int, float>()
            {
                { XDistance.Category, x},
                { YDistance.Category, y}
            };

            IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> fuzzified;
            IList<FuzzyValue<IResultFuzzyMember>> resultMembers;
            
            float output = FuzzyLogicSystem.Evaluate(input, out fuzzified, out resultMembers);

            return output;
        }
    }
}
