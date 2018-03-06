using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System.Collections.Generic;

namespace Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySets.Goalie
{
    class GoalieRelativeAngle : FuzzySet<IInputFuzzyMember>
    {
        public GoalieRelativeAngle(int category) : base(category) { }

        private IInputFuzzyMember _very_right;
        private IInputFuzzyMember _mostly_right;
        //private IInputFuzzyMember _right;
        private IInputFuzzyMember _slightly_right;
        private IInputFuzzyMember _front;
        private IInputFuzzyMember _slightly_left;
        //private IInputFuzzyMember _left;
        private IInputFuzzyMember _mostly_left;
        private IInputFuzzyMember _very_left;

        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            List<IInputFuzzyMember> collection = new List<IInputFuzzyMember>();

            _very_left = new LinearInput("Very Left", this, -180f, true, false, 60f, 0f);
            collection.Add(_very_left);

            _mostly_left = new LinearInput("Right", this, -120f, false, false, 60f, 0f);
            collection.Add(_mostly_left);

            //_left = new LinearInput("Left", this, -90f, false, false, 45f, 0f);
            //collection.Add(_left);

            _slightly_left = new LinearInput("Slightly Left", this, -60f, false, false, 60f, 0f);
            collection.Add(_slightly_left);

            _front = new LinearInput("Front", this, 0f, false, false, 60f, 0);
            collection.Add(_front);

            _slightly_right = new LinearInput("Slightly Right", this, 60f, false, false, 60f, 0f);
            collection.Add(_slightly_right);

            //_right = new LinearInput("Right", this, 90f, false, false, 45f, 0f);
           // collection.Add(_right);

            _mostly_right = new LinearInput("Mostly Right", this, 120f, false, false, 60f, 0f);
            collection.Add(_mostly_right);

            _very_right = new LinearInput("Very Right", this, 180f, false, true, 60f, 0f);
            collection.Add(_very_right);

            return collection;
        }

        public IInputFuzzyMember VeryLeft { get { return _very_left; } }
        public IInputFuzzyMember MostlyLeft { get { return _mostly_left; } }
        //public IInputFuzzyMember Left { get { return _left; } }
        public IInputFuzzyMember SlightlyLeft { get { return _slightly_left; } }
        public IInputFuzzyMember Front { get { return _front; } }
        public IInputFuzzyMember SlightlyRight { get { return _slightly_right; } }
        //public IInputFuzzyMember Right { get { return _right; } }
        public IInputFuzzyMember MostlyRight { get { return _mostly_right; } }
        public IInputFuzzyMember VeryRight { get { return _very_right; } }
    }
}
