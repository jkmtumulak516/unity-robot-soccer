using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets
{
    public class GoalieCategory : FuzzySet<IResultFuzzyMember>
    {
        private IResultFuzzyMember _one;
        private IResultFuzzyMember _two;
        private IResultFuzzyMember _three;
        private IResultFuzzyMember _four;

        public GoalieCategory(int category) : base(category) { }
        
        public IResultFuzzyMember One { get { return _one; } }
        public IResultFuzzyMember Two { get { return _two; } }
        public IResultFuzzyMember Three { get { return _three; } }
        public IResultFuzzyMember Four { get { return _four; } }

        protected override ICollection<IResultFuzzyMember> InitializeMembers()
        {
            var members = new HashSet<IResultFuzzyMember>();

            _one = new LinearResult("One", this, 1f, 1f);
            _two = new LinearResult("Two", this, 2f, 1f);
            _three = new LinearResult("Three", this, 3f, 1f);
            _four = new LinearResult("Four", this, 4f, 1f);
            
            members.Add(_one);
            members.Add(_two);
            members.Add(_three);
            members.Add(_four);

            return members;
        }
    }
}
