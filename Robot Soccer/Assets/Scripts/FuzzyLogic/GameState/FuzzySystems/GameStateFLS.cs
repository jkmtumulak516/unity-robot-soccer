using Assets.Scripts.FuzzyLogic.GameState.FuzzySets;
using FuzzyLogicSystems.Core.Generic;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FuzzyLogic.GameState.FuzzySystems
{
    class GameStateFLS
    {
        private readonly DistanceDifference distanceDifference;
        private readonly DistanceGoal distanceGoal;
        private readonly Orientation orientation;
        private readonly StateValue stateValue;

        private FuzzyLogicSystem fls;
        private List<FuzzySet<IInputFuzzyMember>> listInput;

        public GameStateFLS()
        {
            orientation = new Orientation(1);
            distanceDifference = new DistanceDifference(2);
            distanceGoal = new DistanceGoal(3);
            stateValue = new StateValue(4);
            listInput = new List<FuzzySet<IInputFuzzyMember>>() { orientation, distanceDifference, distanceGoal };

        }

        public IList<ParentRule> CreateRules()
        {
            var listOfRules = new List<ParentRule>();
            var builder = new RuleBuilder();

            //==================================== VERY GOOD ==========================================

            // -----------------------------LEADING WIDELY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.Medium).         Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.DefenseOffense));

            // -----------------------------LEADING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.Medium).         Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.DefenseOffense));

             // -----------------------------SAME --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.Medium).         Build(stateValue.DefenseOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreDefense));

             // -----------------------------LAGGING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.Medium).         Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.MoreDefense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreDefense));

            // -----------------------------LAGGING WIDELY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreDefense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.MoreDefense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.Medium).         Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.MoreDefense));
            listOfRules.Add(builder.  Var(orientation.VeryGood). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreDefense));



            //==================================== GOOD ==========================================

            // -----------------------------LEADING WIDELY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.Medium).         Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.DefenseOffense));

            // -----------------------------LEADING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.Medium).         Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.DefenseOffense));

             // -----------------------------SAME --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.Medium).         Build(stateValue.DefenseOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreDefense));

             // -----------------------------LAGGING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.Medium).         Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.MoreDefense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreDefense));

            // -----------------------------LAGGING WIDELY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreDefense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.MoreDefense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.Medium).         Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.MoreDefense));
            listOfRules.Add(builder.  Var(orientation.Good). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreDefense));



            //==================================== BAD ==========================================

            // -----------------------------LEADING WIDELY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.Medium).         Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LeadingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.DefenseOffense));

            // -----------------------------LEADING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.Medium).         Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.DefenseOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LeadingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.DefenseOffense));

             // -----------------------------SAME --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.VeryNear).       Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.Medium).         Build(stateValue.DefenseOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.Same). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreDefense));

             // -----------------------------LAGGING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.LightOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.DefenseOffense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.Medium).         Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.MoreDefense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LaggingSlightly). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreDefense));

            // -----------------------------LAGGING WIDELY --------------------------------------------
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.ModeratelyNear). Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.Medium).         Build(stateValue.LightDefense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.ModeratelyFar).  Build(stateValue.MoreDefense));
            listOfRules.Add(builder.  Var(orientation.Bad). And().  Var(distanceDifference.LaggingWidely). And().  Var(distanceGoal.VeryNear).       Build(stateValue.MoreDefense));


            return listOfRules;
        }

        public float GetState(float orientation, float distanceDifference, float distanceGoal)
        {
            IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> fuzzified;
            IList<FuzzyValue<IResultFuzzyMember>> evaluated;

            var result = fls.Evaluate(new Dictionary<int, float>
            {
                {this.orientation.Category, orientation},
                {this.distanceDifference.Category, distanceDifference },
                {this.distanceGoal.Category, distanceGoal}
            }, out fuzzified, out evaluated);

            return result;
        }
    }
}
