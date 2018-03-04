using FuzzyLogicSystems.Core.Values;

namespace Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets
{
    public abstract class GoalYDistance : FuzzySet<IInputFuzzyMember>
    {
        protected IInputFuzzyMember _lower;
        protected IInputFuzzyMember _near_lower;
        protected IInputFuzzyMember _center;
        protected IInputFuzzyMember _near_upper;
        protected IInputFuzzyMember _upper;

        public GoalYDistance(int category) : base(category) { }

        public IInputFuzzyMember Lower { get { return _lower; } }
        public IInputFuzzyMember NearLower { get { return _near_lower; } }
        public IInputFuzzyMember Center { get { return _center; } }
        public IInputFuzzyMember NearUpper { get { return _near_upper; } }
        public IInputFuzzyMember Upper { get { return _upper; } }
    }
}
