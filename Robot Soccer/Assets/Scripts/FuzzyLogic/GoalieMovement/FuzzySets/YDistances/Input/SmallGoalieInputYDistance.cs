using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets.YDistances.Input
{
    public class SmallGoalieInputYDistance : GoalieInputYDistance
    {
        public SmallGoalieInputYDistance(int category) : base(category) { }

        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            var members = new HashSet<IInputFuzzyMember>();

            _very_down = new LinearInput("Very Down", this, -50f, true, false, 15f, 0f);
            _moderately_down = new LinearInput("Moderately Down", this, -35f, false, false, 15f, 0f);
            _slightly_down = new LinearInput("Slightly Down", this, -20f, false, false, 10f, 0f);
            _going_down = new LinearInput("Going Down", this, -10f, false, false, 10f, 0f);
            _center = new LinearInput("Center", this, 0f, false, false, 10f, 0f);
            _going_up = new LinearInput("Going Up", this, 10f, false, false, 10f, 0f);
            _slightly_up = new LinearInput("Slightly Up", this, 20f, false, false, 10f, 0f);
            _moderately_up = new LinearInput("Moderately Up", this, 35f, false, false, 15f, 0f);
            _very_up = new LinearInput("Very Up", this, 50f, false, true, 15f, 0f);

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
