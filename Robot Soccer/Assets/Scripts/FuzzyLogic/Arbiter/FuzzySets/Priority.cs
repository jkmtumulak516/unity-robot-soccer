using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FuzzyLogic.Arbiter.FuzzySets
{
    class Priority  : FuzzySet<IResultFuzzyMember>
    {
        public Priority(int category) : base(category)
        {
        }

        private IResultFuzzyMember _low;
        private IResultFuzzyMember _moderately_low;
        private IResultFuzzyMember _medium;
        private IResultFuzzyMember _moderately_high;
        private IResultFuzzyMember _high;

        protected override ICollection<IResultFuzzyMember> InitializeMembers()
        {
            List<IResultFuzzyMember> collection = new List<IResultFuzzyMember>();

            _low = new LinearResult("Low", this, 0, 25, 0);
            collection.Add(_low);

            _moderately_low = new LinearResult("Moderately Low", this, 25, 25, 0);
            collection.Add(_moderately_low);

            _medium = new LinearResult("Medium", this, 50, 25, 0);
            collection.Add(_medium);

            _moderately_high = new LinearResult("Moderately High", this, 75, 25, 0);
            collection.Add(_low);

            _high = new LinearResult("High", this, 100, 25, 0);
            collection.Add(_high);
            

            return collection;
        }

        public IResultFuzzyMember Low { get { return _low; } }
        public IResultFuzzyMember ModeratelyLow{ get { return _moderately_low; } }
        public IResultFuzzyMember Medium { get { return _medium; } }
        public IResultFuzzyMember ModeratelyHigh { get { return _moderately_high; } }
        public IResultFuzzyMember High { get { return _high; } }

    }
}
