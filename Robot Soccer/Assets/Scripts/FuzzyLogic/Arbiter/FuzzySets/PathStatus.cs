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
    class PathStatus : FuzzySet<IInputFuzzyMember>
    {
        public PathStatus(int category) : base(category)
        {
        }

        private IInputFuzzyMember _blocked;
        private IInputFuzzyMember _clear;
        private IInputFuzzyMember _very_clear;



        protected override ICollection<IInputFuzzyMember> InitializeMembers()
        {
            List<IInputFuzzyMember> collection = new List<IInputFuzzyMember>();

            var increment = 10f;
            var peak = 5f;
            var halfWidth = increment;

            _blocked = new LinearInput("Blocked", this, peak, true, false, increment, 0);
            collection.Add(_blocked);

            _clear = new LinearInput("Clear", this, peak += increment, false, false, increment, 0);
            collection.Add(_clear);
            
            _very_clear = new LinearInput("Very Clear", this, peak += increment, false, true, increment, 0);
            collection.Add(_very_clear);

            return collection;

        }

        public IInputFuzzyMember Blocked { get { return _blocked; } }
        public IInputFuzzyMember Clear { get { return _clear; } }
        public IInputFuzzyMember VeryClear  { get { return _very_clear; } }
    }
}
