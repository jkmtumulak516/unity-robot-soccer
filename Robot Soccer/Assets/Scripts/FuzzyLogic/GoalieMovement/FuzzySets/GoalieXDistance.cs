using FuzzyLogicSystems.Core.Values;

namespace Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets
{
    public abstract class GoalieXDistance : FuzzySet<IInputFuzzyMember>
    {
        protected IInputFuzzyMember _inside;
        protected IInputFuzzyMember _slightly_inside;
        protected IInputFuzzyMember _on_goal_line;
        protected IInputFuzzyMember _slightly_outside;
        protected IInputFuzzyMember _moderately_outside;
        protected IInputFuzzyMember _far_outside;
        protected IInputFuzzyMember _very_far_outside;

        public GoalieXDistance(int category) : base(category) { }

        public IInputFuzzyMember Inside { get { return _inside; } }
        public IInputFuzzyMember SlightlyInside{ get { return _slightly_inside; } }
        public IInputFuzzyMember OnGoalLine { get { return _on_goal_line; } }
        public IInputFuzzyMember SlightlyOutside{ get { return _slightly_outside; } }
        public IInputFuzzyMember ModeratelyOutside { get { return _moderately_outside; } }
        public IInputFuzzyMember FarOutside { get { return _far_outside; } }
        public IInputFuzzyMember VeryFarOutside { get { return _very_far_outside; } }
    }
}
