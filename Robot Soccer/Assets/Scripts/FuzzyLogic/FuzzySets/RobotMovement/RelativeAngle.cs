using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FuzzyLogic.FuzzySets.RobotMovement
{
    class RelativeAngle : FuzzySet<IInputFuzzyMember>
    {
        public RelativeAngle(int category) : base(category)
        {
        }

        private IInputFuzzyMember _very_right;
        private IInputFuzzyMember _right;
        private IInputFuzzyMember _slightly_right;
        private IInputFuzzyMember _front;
        private IInputFuzzyMember _slightly_left;
        private IInputFuzzyMember _left;
        private IInputFuzzyMember _very_left;

        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            List<IInputFuzzyMember> collection = new List<IInputFuzzyMember>();

            _very_left = new LinearInput("Very Left", this, -180, true, false, 50, 0);
            collection.Add(_very_left);

            _left = new LinearInput("Left", this, -90, false, false, 50, 0);
            collection.Add(_left);

            _slightly_left = new LinearInput("Slightly Left", this, -45, false, false, 50, 0);
            collection.Add(_slightly_left);

            _front = new LinearInput("Front", this, 0, false, false, 50, 0);
            collection.Add(_front);

            _slightly_right = new LinearInput("Slightly Right", this, 45, false, false, 50, 0);
            collection.Add(_slightly_right);

            _right = new LinearInput("Right", this, 90, false, false, 50, 0);
            collection.Add(_right);

            _very_right = new LinearInput("Very right", this, 180, false, true, 50, 20);
            collection.Add(_very_right);


            return collection;
        }

        public IInputFuzzyMember VeryLeft { get { return _very_left; } }
        public IInputFuzzyMember Left { get { return _left; } }
        public IInputFuzzyMember SlightlyLeft { get { return _slightly_left; } }
        public IInputFuzzyMember Front { get { return _front; } }
        public IInputFuzzyMember SlightlyRight { get { return _slightly_right; } }
        public IInputFuzzyMember Right { get { return _right; } }
        public IInputFuzzyMember VeryRight { get { return _very_right; } }

    }
}
