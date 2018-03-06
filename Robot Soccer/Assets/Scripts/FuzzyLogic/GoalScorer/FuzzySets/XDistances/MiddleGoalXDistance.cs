using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets.XDistances
{
    public class MiddleGoalXDistance : GoalXDistance
    {
        public MiddleGoalXDistance(int category) : base(category) { }

        // TODO: redo the values here
        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            var members = new HashSet<IInputFuzzyMember>();

            _inside = new LinearInput("Inside", this, 7.5f, true, false, 7.5f, 0f);
            _close = new LinearInput("Close", this, 15f, false, false, 7.5f, 0f);
            _far = new LinearInput("Far", this, 22.5f, false, true, 7.5f, 0f);

            members.Add(_close);
            members.Add(_inside);
            members.Add(_far);

            return members;
        }
    }
}
