using FuzzyLogicSystems.Core.Values;

namespace Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets
{
    public abstract class GoalieInputYDistance : FuzzySet<IInputFuzzyMember>
    {
        protected IInputFuzzyMember _very_down;
        protected IInputFuzzyMember _moderately_down;
        protected IInputFuzzyMember _slightly_down;
        protected IInputFuzzyMember _going_down;
        protected IInputFuzzyMember _center;
        protected IInputFuzzyMember _going_up;
        protected IInputFuzzyMember _slightly_up;
        protected IInputFuzzyMember _moderately_up;
        protected IInputFuzzyMember _very_up;

        public GoalieInputYDistance(int category) : base(category) { }

        public IInputFuzzyMember VeryDown { get { return _very_down; } }
        public IInputFuzzyMember ModeratelyDown { get { return _moderately_down; } }
        public IInputFuzzyMember SlightlyDown { get { return _slightly_down; } }
        public IInputFuzzyMember GoingDown { get { return _going_down; } }
        public IInputFuzzyMember Center { get { return _center; } }
        public IInputFuzzyMember GoingUp { get { return _going_up; } }
        public IInputFuzzyMember SlightlyUp { get { return _slightly_up; } }
        public IInputFuzzyMember ModeratelyUp { get { return _moderately_up; } }
        public IInputFuzzyMember VeryUp { get { return _very_up; } }
    }
}
