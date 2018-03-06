using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets.XDistances
{
    class LargeGoalieXDistance : GoalieXDistance
    {
        public LargeGoalieXDistance(int category) : base(category) { }

        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            var members = new HashSet<IInputFuzzyMember>();

            _inside = new LinearInput("Inside", this, 0f, true, false, 2.5f, 0f);
            _slightly_inside = new LinearInput("Slightly Inside", this, 2.5f, false, false, 2.5f, 0f);
            _on_goal_line = new LinearInput("On Goal Line", this, 5f, false, false, 2.5f, 0f);
            _slightly_outside = new LinearInput("Slightly Outside", this, 10f, false, false, 5f, 0f);
            _moderately_outside = new LinearInput("Moderately Outside", this, 15f, false, false, 5f, 0f);
            _far_outside = new LinearInput("Far Outside", this, 20f, false, false, 5f, 0f);
            _very_far_outside = new LinearInput("Very Far Outside", this, 25f, false, true, 5f, 0f);

            members.Add(_inside);
            members.Add(_slightly_inside);
            members.Add(_on_goal_line);
            members.Add(_slightly_outside);
            members.Add(_moderately_outside);
            members.Add(_far_outside);
            members.Add(_very_far_outside);

            return members;
        }
    }
}
