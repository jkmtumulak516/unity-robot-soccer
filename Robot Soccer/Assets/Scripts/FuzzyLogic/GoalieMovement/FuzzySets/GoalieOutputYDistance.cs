using FuzzyLogicSystems.Core.Values;

namespace Assets.Scripts.FuzzyLogic.GoalieMovement.FuzzySets
{
    public abstract class GoalieOutputYDistance : FuzzySet<IResultFuzzyMember>
    {
        protected IResultFuzzyMember _very_down;
        protected IResultFuzzyMember _moderately_down;
        protected IResultFuzzyMember _slightly_down;
        protected IResultFuzzyMember _going_down;
        protected IResultFuzzyMember _center;
        protected IResultFuzzyMember _going_up;
        protected IResultFuzzyMember _slightly_up;
        protected IResultFuzzyMember _moderately_up;
        protected IResultFuzzyMember _very_up;

        public GoalieOutputYDistance(int category) : base(category) { }

        public IResultFuzzyMember VeryDown { get { return _very_down; } }
        public IResultFuzzyMember ModeratelyDown { get { return _moderately_down; } }
        public IResultFuzzyMember SlightlyDown { get { return _slightly_down; } }
        public IResultFuzzyMember GoingDown { get { return _going_down; } }
        public IResultFuzzyMember Center { get { return _center; } }
        public IResultFuzzyMember GoingUp { get { return _going_up; } }
        public IResultFuzzyMember SlightlyUp { get { return _slightly_up; } }
        public IResultFuzzyMember ModeratelyUp { get { return _moderately_up; } }
        public IResultFuzzyMember VeryUp { get { return _very_up; } }
    }
}
