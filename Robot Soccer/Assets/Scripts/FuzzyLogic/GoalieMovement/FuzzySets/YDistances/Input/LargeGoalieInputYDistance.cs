using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets.YDistances.Input
{
    public class LargeGoalieInputYDistance : GoalieInputYDistance
    {
        public LargeGoalieInputYDistance(int category) : base(category) { }

        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            var members = new HashSet<IInputFuzzyMember>();

            _very_down = new LinearInput("Very Down", this, -55f, true, false, 15f, 0f);
            _moderately_down = new LinearInput("Moderately Down", this, -35f, false, false, 15f, 0f);
            _slightly_down = new LinearInput("Slightly Down", this, -25f, false, false, 12.5f, 0f);
            _going_down = new LinearInput("Going Down", this, -12.5f, false, false, 12.5f, 0f);
            _center = new LinearInput("Center", this, 0f, false, false, 12.5f, 0f);
            _going_up = new LinearInput("Going Up", this, 12.5f, false, false, 12.5f, 0f);
            _slightly_up = new LinearInput("Slightly Up", this, 25f, false, false, 12.5f, 0f);
            _moderately_up = new LinearInput("Moderately Up", this, 35f, false, false, 15f, 0f);
            _very_up = new LinearInput("Very Up", this, 55f, false, true, 15f, 0f);

            members.Add(_very_down);
            members.Add(_moderately_down);
            members.Add(_slightly_down);
            members.Add(_going_down);
            members.Add(_center);
            members.Add(_going_up);
            members.Add(_slightly_up);
            members.Add(_moderately_up);
            members.Add(_very_up);

            return members;
        }
    }
}
