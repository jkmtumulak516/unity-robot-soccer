using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets.YDistances
{
    public class LargeYDistance : GoalYDistance
    {
        public LargeYDistance(int category) : base(category) { }

        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            var members = new HashSet<IInputFuzzyMember>();

            _lower = new LinearInput("Lower", this, 50f, true, false, 5f, 0f);
            _near_lower = new LinearInput("Near Lower", this, 57.5f, false, false, 7.5f, 0f);
            _center = new LinearInput("Center", this, 65f, false, false, 10f, 0f);
            _near_upper = new LinearInput("Near Upper", this, 72.5f, false, false, 7.5f, 0f);
            _upper = new LinearInput("Upper", this, 80f, false, true, 5f, 0f);

            members.Add(_lower);
            members.Add(_near_lower);
            members.Add(_center);
            members.Add(_near_upper);
            members.Add(_upper);

            return members;
        }
    }
}
