using Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySets;
using FuzzyLogicSystems.Core;
using FuzzyLogicSystems.Core.Generic;
using FuzzyLogicSystems.Core.Generic.Defuzzifier;
using FuzzyLogicSystems.Core.Generic.Fuzzifier;
using FuzzyLogicSystems.Core.Values;
using System.Collections.Generic;

namespace Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySystems.Shooting
{
    public class ShootingRightWheelFLS
    {
        private readonly RelativeAngle robotBallAngle;
        private readonly RelativeAngle goalBallAngle;
        private readonly RelativeAngle robotGoalAngle;
        private readonly Distance distance;
        private readonly Torque torque;
        private FuzzyLogicSystem fls;
        private List<FuzzySet<IInputFuzzyMember>> listInput;

        public ShootingRightWheelFLS(IFuzzyRuleBase ruleBase)
        {
            robotBallAngle = FuzzyShootingUtil.RobotBallAngleSet;
            goalBallAngle = FuzzyShootingUtil.GoalBallAngleSet;
            robotGoalAngle = FuzzyShootingUtil.RobotGoalAngleSet;
            distance = FuzzyShootingUtil.DistanceSet;
            torque = FuzzyShootingUtil.TorqueSet;
            listInput = new List<FuzzySet<IInputFuzzyMember>>() { robotBallAngle, goalBallAngle, robotGoalAngle, distance };

            fls = new FuzzyLogicSystem(new Fuzzifier(), new CenterOfSumsDefuzzifier(), ruleBase);
        }

        public float GetTorque(float robotBallAngle, float goalBallAngle, float robotGoalAngle, float distance)
        {
            IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> fuzzified;
            IList<FuzzyValue<IResultFuzzyMember>> evaluated;
            var result = fls.Evaluate(new Dictionary<int, float>
            {
                {this.robotBallAngle.Category, robotBallAngle },
                {this.goalBallAngle.Category, goalBallAngle },
                {this.robotGoalAngle.Category, robotGoalAngle },
                {this.distance.Category, distance }
            }, out fuzzified, out evaluated);

            return result;
        }
    }
}
