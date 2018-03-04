using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets.XDistances
{
    public class LargeXDistance : GoalXDistance
    {
        public LargeXDistance(int category) : base(category) { }

        // TODO: redo the values here
        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            var members = new HashSet<IInputFuzzyMember>();

            _inside = new LinearInput("Inside", this, 8f, true, false, 8f, 0f);
            _close = new LinearInput("Close", this, 16f, false, false, 8f, 0f);
            _far = new LinearInput("Far", this, 24f, false, true, 8f, 0f);

            members.Add(_close);
            members.Add(_inside);
            members.Add(_far);

            return members;
        }
    }
}
