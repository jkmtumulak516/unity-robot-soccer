using Assets.Scripts.Game;
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
    class BallYLocation : FuzzySet<IInputFuzzyMember>
    {
        public BallYLocation(int category) : base(category)
        {
        }

        private IInputFuzzyMember _extremely_low;
        private IInputFuzzyMember _near_low;
        private IInputFuzzyMember _near_high;
        private IInputFuzzyMember _high;



        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            List<IInputFuzzyMember> collection = new List<IInputFuzzyMember>();

            var gm = GameObject.Find("ConfigurationHolder").GetComponent<ConfigurationHolder>();
            float goal = 0;
            switch (gm.c.NumberOfRobots)
            {
                case 3:
                    goal = League.Small.GoalHeight;
                    break;
                case 5:
                    goal = League.Middle.GoalHeight;
                    break;
                case 11:
                    goal = League.Large.GoalHeight;
                    break;

            }

            var increment = goal / 3;
            var peak = -(goal / 2);
            var halfWidth = increment;

            _extremely_low = new LinearInput("Extremely Low", this, peak, true, false, increment, 0);
            collection.Add(_extremely_low);

            _near_low = new LinearInput("Near Low", this, peak += increment, false, false, increment, 0);
            collection.Add(_near_low);

            _near_high = new LinearInput("Near High", this, peak += increment, false, false, increment, 0);
            collection.Add(_near_high);

            _high = new LinearInput("High", this, peak += increment, false, true, increment, 0);
            collection.Add(_high);

            return collection;

        }

        public IInputFuzzyMember ExtremelyLow { get { return _extremely_low; } }
        public IInputFuzzyMember NearLow { get { return _near_low; } }
        public IInputFuzzyMember NearHigh { get { return _near_high; } }
        public IInputFuzzyMember High  { get { return _high; } }
    }
}
