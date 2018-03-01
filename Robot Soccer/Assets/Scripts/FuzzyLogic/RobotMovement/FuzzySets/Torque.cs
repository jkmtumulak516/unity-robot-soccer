using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySets
{
    class Torque : FuzzySet<IResultFuzzyMember>
    {
        public Torque(int category) : base(category)
        {
        }

        private IResultFuzzyMember _fast_backward;
        private IResultFuzzyMember _backward;
        private IResultFuzzyMember _slow_backward;
        private IResultFuzzyMember _stop;
        private IResultFuzzyMember _slow_forward;
        private IResultFuzzyMember _forward;
        private IResultFuzzyMember _fast_forward;

        protected override ICollection<IResultFuzzyMember> InitializeMembers()
        {
            List<IResultFuzzyMember> collection = new List<IResultFuzzyMember>();

            _fast_backward = new LinearResult("Fast Backward", this, -150, 40, 0);
            collection.Add(_fast_backward);

            _backward = new LinearResult("Backward", this, -100, 40, 0);
            collection.Add(_backward);

            _slow_backward = new LinearResult("Fast Backward", this, -50, 40, 0);
            collection.Add(_slow_backward);

            _stop = new LinearResult("Stop", this, 0, 40, 0);
            collection.Add(_fast_backward);

            _slow_forward = new LinearResult("Slow Forward", this, 50, 40, 0);
            collection.Add(_slow_forward);

            _forward = new LinearResult("Forward", this, 100, 40, 0);
            collection.Add(_forward);

            _fast_forward = new LinearResult("Fast Forward", this, 150, 40, 0);
            collection.Add(_fast_forward);


            return collection;
        }

        public IResultFuzzyMember FastBackward { get { return _fast_backward; } }
        public IResultFuzzyMember Backward { get { return _backward; } }
        public IResultFuzzyMember SlowBackward { get { return _slow_backward; } }
        public IResultFuzzyMember Stop { get { return _stop; } }
        public IResultFuzzyMember SlowForward { get { return _slow_forward; } }
        public IResultFuzzyMember Forward { get { return _forward; } }
        public IResultFuzzyMember FastForward { get { return _fast_forward; } }

    }
}
