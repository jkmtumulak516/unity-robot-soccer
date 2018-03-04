using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets
{
    public class GoalConsequence : FuzzySet<IResultFuzzyMember>
    {
        private IResultFuzzyMember _poor;
        private IResultFuzzyMember _needs_improvement;
        private IResultFuzzyMember _average;
        private IResultFuzzyMember _satisfactory;
        private IResultFuzzyMember _very_good;

        public GoalConsequence(int category) : base(category) { }

        public IResultFuzzyMember Poor { get { return _poor; } }
        public IResultFuzzyMember NeedsImprovement { get { return _needs_improvement; } }
        public IResultFuzzyMember Average { get { return _average; } }
        public IResultFuzzyMember Satisfactory { get { return _satisfactory; } }
        public IResultFuzzyMember VeryGood { get { return _very_good; } }

        protected override ICollection<IResultFuzzyMember> InitializeMembers()
        {
            var members = new HashSet<IResultFuzzyMember>();

            _poor = new LinearResult("Poor", this, 0, 25f);
            _needs_improvement = new LinearResult("Needs Improvement", this, 25f, 25f);
            _average = new LinearResult("Average", this, 50f, 25f);
            _satisfactory = new LinearResult("Satisfactory", this, 75f, 25f);
            _very_good = new LinearResult("Very Good", this, 100f, 25f);

            members.Add(_poor);
            members.Add(_needs_improvement);
            members.Add(_average);
            members.Add(_satisfactory);
            members.Add(_very_good);

            return members;
        }
    }
}
