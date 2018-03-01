using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySets
{
    class Distance : FuzzySet<IInputFuzzyMember>
    {
        float Max; 
        public Distance(int category, float Max) : base(category)
        {
            this.Max = Max;
        }

        private IInputFuzzyMember _very_near;
        private IInputFuzzyMember _near;
        private IInputFuzzyMember _medium;
        private IInputFuzzyMember _far;
        private IInputFuzzyMember _very_far;



        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            List<IInputFuzzyMember> collection = new List<IInputFuzzyMember>();

            var increment = Max / 5;
            var peak = 0f;
            var halfWidth = increment / 2;

            _very_near = new LinearInput("Very Near", this, peak, true, false, halfWidth, 0);
            collection.Add(_very_near);

            _near = new LinearInput("Near", this, peak += increment, false, false, halfWidth, 0);
            collection.Add(_near);

            _medium = new LinearInput("Medium", this, peak += increment, false, false, halfWidth, 0);
            collection.Add(_medium);

            _far = new LinearInput("Far", this, peak += increment, false, false, halfWidth, 0);
            collection.Add(_far);

            _very_far = new LinearInput("Very far", this, peak += increment, false, true, halfWidth, 0);
            collection.Add(_very_far);

            return collection;

        }

        public IInputFuzzyMember VeryNear { get { return _very_near; } }
        public IInputFuzzyMember Near { get { return _near; } }
        public IInputFuzzyMember Medium { get { return _medium; } }
        public IInputFuzzyMember Far { get { return _far; } }
        public IInputFuzzyMember VeryFar { get { return _very_far; } }
    }

}
