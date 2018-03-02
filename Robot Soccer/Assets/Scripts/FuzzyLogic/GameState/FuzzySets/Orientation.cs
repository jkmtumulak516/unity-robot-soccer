using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FuzzyLogic.GameState.FuzzySets
{
    class Orientation : FuzzySet<IInputFuzzyMember>
    {
        public Orientation(int category) : base(category)
        {
        }

        private IInputFuzzyMember _very_good;
        private IInputFuzzyMember _good;
        private IInputFuzzyMember _bad;



        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            List<IInputFuzzyMember> collection = new List<IInputFuzzyMember>();
            var increment = 45;
            var peak = 0f;
            var halfWidth = increment;

            _very_good = new LinearInput("Very Near", this, peak, true, false, halfWidth, 0);
            collection.Add(_very_good);

            _good = new LinearInput("Near", this, peak += increment, false, false, halfWidth, 0);
            collection.Add(_good);
            
            _bad = new LinearInput("Very far", this, peak += increment, false, true, halfWidth, 0);
            collection.Add(_bad);

            return collection;

        }

        public IInputFuzzyMember VeryGood { get { return _very_good; } }
        public IInputFuzzyMember Good { get { return _good; } }
        public IInputFuzzyMember Bad { get { return _bad; } }
    }
}
