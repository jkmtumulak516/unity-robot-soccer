using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets.XDistances
{
    public class SmallXDistance : GoalXDistance
    {
        public SmallXDistance(int category) : base(category) { }

        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            var members = new HashSet<IInputFuzzyMember>();

            _inside = new LinearInput("Inside", this, 5f, true, false, 5f, 0f);
            _close = new LinearInput("Close", this, 10f, false, false, 5f, 0f);
            _far = new LinearInput("Far", this, 15f, false, true, 5f, 0f);

            members.Add(_close);
            members.Add(_inside);
            members.Add(_far);

            return members;
        }
    }
}
