using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.FuzzyLogic.Arbiter.FuzzySets
{
    class BallXLocation : FuzzySet<IInputFuzzyMember>
    {
        public BallXLocation(int category) : base(category)
        {
        }

        private IInputFuzzyMember _very_near;
        private IInputFuzzyMember _moderately_near;
        private IInputFuzzyMember _near;
        private IInputFuzzyMember _far;
        private IInputFuzzyMember _very_far;



        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            List<IInputFuzzyMember> collection = new List<IInputFuzzyMember>();

            var gm = GameObject.Find("ConfigurationHolder").GetComponent<ConfigurationHolder>();
            var increment = gm.c.FieldWidth / 4;
            var peak = -(gm.c.FieldWidth / 2);
            var halfWidth = increment;

            _very_near = new LinearInput("Very Near", this, peak, true, false, halfWidth, 0);
            collection.Add(_very_near);

            _moderately_near = new LinearInput("Moderately Near", this, peak += increment, false, false, halfWidth, 0);
            collection.Add(_moderately_near);

            _near = new LinearInput("Near", this, peak += increment, false, false, halfWidth, 0);
            collection.Add(_near);

            _far = new LinearInput("Far", this, peak += increment, false, false, halfWidth, 0);
            collection.Add(_far);

            _very_far = new LinearInput("Very Far", this, peak += increment, false, true, halfWidth, 0);
            collection.Add(_very_far);

            return collection;

        }

        public IInputFuzzyMember VeryNear { get { return _very_near; } }
        public IInputFuzzyMember ModeratelyNear { get { return _moderately_near; } }
        public IInputFuzzyMember Near { get { return _near; } }
        public IInputFuzzyMember Far { get { return _far; } }
        public IInputFuzzyMember VeryFar  { get { return _very_far; } }
    }
}
