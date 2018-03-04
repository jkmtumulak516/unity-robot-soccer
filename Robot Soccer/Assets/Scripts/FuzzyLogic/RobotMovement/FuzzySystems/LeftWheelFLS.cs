using Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySets;
using FuzzyLogicSystems.Core.Generic;
using FuzzyLogicSystems.Core.Generic.Defuzzifier;
using FuzzyLogicSystems.Core.Generic.Fuzzifier;
using FuzzyLogicSystems.Core.Generic.RuleBase;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LeftWheelFLS
{
    private readonly RelativeAngle angle;
    private readonly Distance distance;
    private readonly Torque torque;
    private FuzzyLogicSystem fls;
    private List<FuzzySet<IInputFuzzyMember>> listInput;

    public LeftWheelFLS()
    {
        angle = new RelativeAngle(1);
        distance = new Distance(2);
        torque = new Torque(3);
        listInput = new List<FuzzySet<IInputFuzzyMember>>() { angle, distance };
        var rules = CreateRules();
        var ruleBase = new EvaluationTreeRuleBase(listInput, torque, rules);

        fls = new FuzzyLogicSystem(new Fuzzifier(), new CenterOfSumsDefuzzifier(), ruleBase);
    }


    public List<ParentRule> CreateRules()
    {
        var listOfRules = new List<ParentRule>();
        var builder = new RuleBuilder();

        //Very Left
        listOfRules.Add(builder.Var(angle.VeryLeft).And().Var(distance.VeryNear).Build(torque.FastBackward));
        listOfRules.Add(builder.Var(angle.VeryLeft).And().Var(distance.Near).Build(torque.Backward));
        listOfRules.Add(builder.Var(angle.VeryLeft).And().Var(distance.Medium).Build(torque.SlowBackward));
        listOfRules.Add(builder.Var(angle.VeryLeft).And().Var(distance.Far).Build(torque.SlowBackward));
        listOfRules.Add(builder.Var(angle.VeryLeft).And().Var(distance.VeryFar).Build(torque.Stop));

        //Left
        listOfRules.Add(builder.Var(angle.Left).And().Var(distance.VeryNear).Build(torque.FastBackward));
        listOfRules.Add(builder.Var(angle.Left).And().Var(distance.Near).Build(torque.Backward));
        listOfRules.Add(builder.Var(angle.Left).And().Var(distance.Medium).Build(torque.SlowBackward));
        listOfRules.Add(builder.Var(angle.Left).And().Var(distance.Far).Build(torque.SlowBackward));
        listOfRules.Add(builder.Var(angle.Left).And().Var(distance.VeryFar).Build(torque.SlowForward));

        //Slightly Left
        listOfRules.Add(builder.Var(angle.SlightlyLeft).And().Var(distance.VeryNear).Build(torque.Backward));
        listOfRules.Add(builder.Var(angle.SlightlyLeft).And().Var(distance.Near).Build(torque.Stop));
        listOfRules.Add(builder.Var(angle.SlightlyLeft).And().Var(distance.Medium).Build(torque.SlowForward));
        listOfRules.Add(builder.Var(angle.SlightlyLeft).And().Var(distance.Far).Build(torque.Forward));
        listOfRules.Add(builder.Var(angle.SlightlyLeft).And().Var(distance.VeryFar).Build(torque.FastForward));

        //Front
        listOfRules.Add(builder.Var(angle.Front).And().Var(distance.VeryNear).Build(torque.Stop));
        listOfRules.Add(builder.Var(angle.Front).And().Var(distance.Near).Build(torque.Forward));
        listOfRules.Add(builder.Var(angle.Front).And().Var(distance.Medium).Build(torque.Forward));
        listOfRules.Add(builder.Var(angle.Front).And().Var(distance.Far).Build(torque.FastForward));
        listOfRules.Add(builder.Var(angle.Front).And().Var(distance.VeryFar).Build(torque.FastForward));

        //Slightly Right
        listOfRules.Add(builder.Var(angle.SlightlyRight).And().Var(distance.VeryNear).Build(torque.Forward));
        listOfRules.Add(builder.Var(angle.SlightlyRight).And().Var(distance.Near).Build(torque.Forward));
        listOfRules.Add(builder.Var(angle.SlightlyRight).And().Var(distance.Medium).Build(torque.Forward));
        listOfRules.Add(builder.Var(angle.SlightlyRight).And().Var(distance.Far).Build(torque.FastForward));
        listOfRules.Add(builder.Var(angle.SlightlyRight).And().Var(distance.VeryFar).Build(torque.FastForward));

        //Right
        listOfRules.Add(builder.Var(angle.Right).And().Var(distance.VeryNear).Build(torque.FastForward));
        listOfRules.Add(builder.Var(angle.Right).And().Var(distance.Near).Build(torque.Forward));
        listOfRules.Add(builder.Var(angle.Right).And().Var(distance.Medium).Build(torque.FastForward));
        listOfRules.Add(builder.Var(angle.Right).And().Var(distance.Far).Build(torque.FastForward));
        listOfRules.Add(builder.Var(angle.Right).And().Var(distance.VeryFar).Build(torque.FastForward));

        //Very Right
        listOfRules.Add(builder.Var(angle.VeryRight).And().Var(distance.VeryNear).Build(torque.FastForward));
        listOfRules.Add(builder.Var(angle.VeryRight).And().Var(distance.Near).Build(torque.FastForward));
        listOfRules.Add(builder.Var(angle.VeryRight).And().Var(distance.Medium).Build(torque.Forward));
        listOfRules.Add(builder.Var(angle.VeryRight).And().Var(distance.Far).Build(torque.Forward));
        listOfRules.Add(builder.Var(angle.VeryRight).And().Var(distance.VeryFar).Build(torque.Forward));

        return listOfRules;
    }

    public float GetTorque(float angle, float distance)
    {
        IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> fuzzified;
        IList<FuzzyValue<IResultFuzzyMember>> evaluated;
        var result = fls.Evaluate(new Dictionary<int, float>
        {
            {this.angle.Category, angle },
            {this.distance.Category, distance }
        }, out fuzzified, out evaluated);
        //Debug.Log("------------------Left------------------");
        //Debug.Log("[Angle]");
        //foreach (var fuz in fuzzified[1]){
        //    Debug.Log(fuz.FuzzyMember.Name + " : " + fuz.Degree );
        //}

        //Debug.Log("[Distance]");
        //foreach (var fuz in fuzzified[2])
        //{
        //    Debug.Log(fuz.FuzzyMember.Name + " : " + fuz.Degree );
        //}

        //Debug.Log("[Result]");
        //foreach (var fuz in evaluated)
        //{
        //    Debug.Log(fuz.FuzzyMember.Name + " : " + fuz.Degree);
        //}

        return result;
    }

}