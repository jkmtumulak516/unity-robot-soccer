using FuzzyLogicSystems.Core.Values;

namespace Assets.Scripts.FuzzyLogic.GoalScorer.FuzzySets
{
    public abstract class GoalXDistance : FuzzySet<IInputFuzzyMember>
    {
        protected IInputFuzzyMember _inside;
        protected IInputFuzzyMember _close;
        protected IInputFuzzyMember _far;

        public GoalXDistance(int category) : base(category) { }

        public IInputFuzzyMember Inside { get { return _inside; } }
        public IInputFuzzyMember Close { get { return _close; } }
        public IInputFuzzyMember Far { get { return _far; } }
    }
}
