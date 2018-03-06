using System;
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
    public class GoalieStrategy
    {
        private readonly GoalieInputYDistance _ball_distance;
        private readonly GoalieInputYDistance _goalie_distance;
        private readonly GoalieOutputYDistance _y_output;

        private readonly IFuzzyRuleBase _rule_base;
        private readonly IFuzzyLogicSystem _fls;

        public GoalieStrategy(int strategyNumber, GoalieInputYDistance ballDistance, GoalieInputYDistance goalieDistance, GoalieOutputYDistance yOutput)
        {
            _ball_distance = ballDistance;
            _goalie_distance = goalieDistance;
            _y_output = yOutput;

            List<ParentRule> rules;

            switch (strategyNumber)
            {
                case 1: rules = CreateRules1();
                    break;
                case 2: rules = CreateRules2();
                    break;
                case 3: rules = CreateRules3();
                    break;
                case 4: rules = CreateRules4();
                    break;
                default: throw new ArgumentException("Startegy Number must be a number from 1 to 4 inclusive.");
            }

            _rule_base = new EvaluationTreeRuleBase(
                new List<FuzzySet<IInputFuzzyMember>>() { _ball_distance, _goalie_distance },
                _y_output, rules);

            _fls = new FuzzyLogicSystem(new Fuzzifier(), new CenterOfSumsDefuzzifier(), _rule_base);
        }

        private GoalieInputYDistance BallDistance { get { return _ball_distance; } }
        private GoalieInputYDistance GoalieDistance { get { return _goalie_distance; } }
        private GoalieOutputYDistance Output { get { return _y_output; } }

        private IFuzzyRuleBase RuleBase { get { return _rule_base; } }
        private IFuzzyLogicSystem FuzzyLogicSystem { get { return _fls; } }

        public float GetOutput(float ballY, float goalieY)
        {
            var input = new Dictionary<int, float>()
            {
                { BallDistance.Category, ballY },
                { GoalieDistance.Category, goalieY }
            };

            IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> fuzzified;
            IList<FuzzyValue<IResultFuzzyMember>> resultMembers;

            float output = FuzzyLogicSystem.Evaluate(input, out fuzzified, out resultMembers);

            return output;
        }

        private List<ParentRule> CreateRules1()
        {
            var rules = new List<ParentRule>(BallDistance.Members.Count * GoalieDistance.Members.Count);
            var rb = new RuleBuilder();

            // Goalie Very Down
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Moderately Down
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Slightly Down
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Going Down
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Center
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Going Up
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Slightly Up
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Moderately Up
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Very Up
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            return rules;
        }

        private List<ParentRule> CreateRules2()
        {
            var rules = new List<ParentRule>(BallDistance.Members.Count * GoalieDistance.Members.Count);
            var rb = new RuleBuilder();

            // Goalie Very Down
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.GoingDown).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.Center).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.GoingUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Moderately Down
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.GoingDown).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.Center).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.GoingUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Slightly Down
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.GoingDown).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.Center).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.GoingUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Going Down
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.Center).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.GoingUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Center
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.GoingDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.GoingUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Going Up
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.GoingDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.Center).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Slightly Up
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.GoingDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.Center).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.GoingUp).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Moderately Up
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.GoingDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.Center).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.GoingUp).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Very Up
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.GoingDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.Center).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.GoingUp).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            return rules;
        }

        // TODO: Finish these rules
        private List<ParentRule> CreateRules3()
        {
            var rules = new List<ParentRule>(BallDistance.Members.Count * GoalieDistance.Members.Count);
            var rb = new RuleBuilder();

            // Goalie Very Down
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.SlightlyDown).Build(Output.ModeratelyDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Moderately Down
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Slightly Down
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Going Down
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Center
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Going Up
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Slightly Up
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Moderately Up
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Very Up
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            return rules;
        }

        private List<ParentRule> CreateRules4()
        {
            var rules = new List<ParentRule>(BallDistance.Members.Count * GoalieDistance.Members.Count);
            var rb = new RuleBuilder();

            // Goalie Very Down
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Moderately Down
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Slightly Down
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Going Down
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingDown).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Center
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.Center).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Going Up
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.GoingUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Slightly Up
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.SlightlyUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Moderately Up
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.ModeratelyUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            // Goalie Very Up
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.VeryDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.ModeratelyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.SlightlyDown).Build(Output.SlightlyDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.GoingDown).Build(Output.GoingDown));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.Center).Build(Output.Center));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.GoingUp).Build(Output.GoingUp));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.SlightlyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.ModeratelyUp).Build(Output.SlightlyUp));
            rules.Add(rb.Var(GoalieDistance.VeryUp).And().Var(BallDistance.VeryUp).Build(Output.SlightlyUp));

            return rules;
        }
    }
}
