﻿using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.FuzzyLogic.GameState.FuzzySets
{
    class DistanceDifference : FuzzySet<IInputFuzzyMember>
    {
        public DistanceDifference(int category) : base(category)
        {
        }

        private IInputFuzzyMember _leading_widely;
        private IInputFuzzyMember _leading_slightly;
        private IInputFuzzyMember _same;
        private IInputFuzzyMember _lagging_slightly;
        private IInputFuzzyMember _lagging_widely;



        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            List<IInputFuzzyMember> collection = new List<IInputFuzzyMember>();
            var increment = 10;
            var peak = -20f;

            _leading_widely = new LinearInput("Leading Widely", this, peak, true, false, increment, 0);
            collection.Add(_leading_widely);

            _leading_slightly = new LinearInput("Leading Slightly", this, peak += increment, false, false, increment, 0);
            collection.Add(_leading_slightly);

            _same = new LinearInput("Same", this, peak += increment, false, false, increment, 0);
            collection.Add(_same);

            _lagging_slightly = new LinearInput("Lagging Slightly", this, peak += increment, false, false, increment, 0);
            collection.Add(_lagging_slightly);

            _lagging_widely = new LinearInput("Lagging Widely", this, peak += increment, false, true, increment, 0);
            collection.Add(_lagging_widely);

            return collection;

        }

        public IInputFuzzyMember LeadingWidely { get { return _leading_widely; } }
        public IInputFuzzyMember LeadingSlightly { get { return _leading_slightly; } }
        public IInputFuzzyMember Same { get { return _same; } }
        public IInputFuzzyMember LaggingSlightly { get { return _lagging_slightly; } }
        public IInputFuzzyMember LaggingWidely { get { return _lagging_widely; } }
    }
}
