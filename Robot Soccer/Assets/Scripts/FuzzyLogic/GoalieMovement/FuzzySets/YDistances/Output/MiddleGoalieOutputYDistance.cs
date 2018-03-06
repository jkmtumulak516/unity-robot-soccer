using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets.YDistances.Output
{
    public class MiddleGoalieOutputYDistance : GoalieOutputYDistance
    {
        public MiddleGoalieOutputYDistance(int category) : base(category) { }

        protected override ICollection<IResultFuzzyMember> InitializeMembers()
        {
            var members = new HashSet<IResultFuzzyMember>();

            _very_down = new LinearResult("Very Down", this, -40f, 15f, 0f);
            _moderately_down = new LinearResult("Moderately Down", this, -35f, 15f, 0f);
            _slightly_down = new LinearResult("Slightly Down", this, -30f, 15f, 0f);
            _going_down = new LinearResult("Going Down", this, -15f, 10f, 0f);
            _center = new LinearResult("Center", this, 0f, 15f, 0f);
            _going_up = new LinearResult("Going Up", this, 15f, 15f, 0f);
            _slightly_up = new LinearResult("Slightly Up", this, 30f, 15f, 0f);
            _moderately_up = new LinearResult("Moderately Up", this, 35f, 15f, 0f);
            _very_up = new LinearResult("Very Up", this, 40f, 15f, 0f);

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
