using Assets.Scripts.FuzzyLogic.Arbiter.FuzzySets;
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

namespace Assets.Scripts.FuzzyLogic.Arbiter.FuzzySystems
{
    class ArbiterFLS
    {
        private readonly BallXLocation BallX;
        private readonly BallYLocation BallY;
        private readonly PathStatus Pass;
        private readonly PathStatus Shoot;
        private readonly Priority Priority;
        private FuzzyLogicSystem fls;
        private List<FuzzySet<IInputFuzzyMember>> listInput;

        public ArbiterFLS()
        {
            Shoot = new PathStatus(1);
            Pass = new PathStatus(2);
            BallX = new BallXLocation(3);
            BallY = new BallYLocation(4);
            Priority = new Priority(5);
            listInput = new List<FuzzySet<IInputFuzzyMember>>() { Shoot, Pass, BallX, BallY };

            var rules = CreateRules();
            var ruleBase = new EvaluationTreeRuleBase(listInput, Priority, rules);

            fls = new FuzzyLogicSystem(new Fuzzifier(), new CenterOfSumsDefuzzifier(), ruleBase);
        }

        public List<ParentRule> CreateRules()
        {
            var listOfRules = new List<ParentRule>();
            var builder = new RuleBuilder();

            // ========================= SHOOT BLOCKED ================================
            { 
                // +++++++++++++++++++++++++ PASS BLOCKED +++++++++++++++++++++++++++++++++
                { 
                    //-------------------------- X VERY NEAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.NearLow).         Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.NearHigh).        Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.High).            Build(Priority.Low));

                    //-------------------------- X MODERATELY NEAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearLow).         Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearHigh).        Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.High).            Build(Priority.Low));

                    //-------------------------- X NEAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.ExtremelyLow).    Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.NearLow).         Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.NearHigh).        Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.High).            Build(Priority.Low));

                    //-------------------------- X FAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.ExtremelyLow).    Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.NearLow).         Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.NearHigh).        Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.High).            Build(Priority.Low));

                    //-------------------------- X VERY FAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.ExtremelyLow).    Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.NearLow).         Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.NearHigh).        Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.High).            Build(Priority.Low));
                }

                // +++++++++++++++++++++++++ PASS CLEAR +++++++++++++++++++++++++++++++++
                { 
                    //-------------------------- X VERY NEAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.High).            Build(Priority.ModeratelyLow));

                    //-------------------------- X MODERATELY NEAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.High).            Build(Priority.ModeratelyLow));

                    //-------------------------- X NEAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.NearLow).         Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.NearHigh).        Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.High).            Build(Priority.Medium));

                    //-------------------------- X FAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.High).            Build(Priority.ModeratelyHigh));

                    //-------------------------- X VERY FAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.High).            Build(Priority.ModeratelyHigh));
                }

                // +++++++++++++++++++++++++ PASS VERY CLEAR +++++++++++++++++++++++++++++++++
                { 
                    //-------------------------- X VERY NEAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.High).            Build(Priority.ModeratelyLow));

                    //-------------------------- X MODERATELY NEAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearLow).         Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearHigh).        Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.High).            Build(Priority.Medium));

                    //-------------------------- X NEAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.NearLow).         Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.NearHigh).        Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.High).            Build(Priority.Medium));

                    //-------------------------- X FAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.NearLow).         Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.NearHigh).        Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.High).            Build(Priority.Medium));

                    //-------------------------- X VERY FAR ------------------------------------
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearLow).         Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearHigh).        Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Blocked).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.High).            Build(Priority.Medium));
                }
                

            }

            // ========================= SHOOT CLEAR ================================
            { 
                // +++++++++++++++++++++++++ PASS BLOCKED +++++++++++++++++++++++++++++++++
                { 
                    // X VERY NEAR 
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.NearLow).         Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.NearHigh).        Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.High).            Build(Priority.Low));
                                                          
                    //X MODERATELY NEAR
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearLow).         Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearHigh).        Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.High).            Build(Priority.Low));
                                                         
                    //X NEAR
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.High).            Build(Priority.ModeratelyLow));
                                                          
                    //X FAR 
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.NearLow).         Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.NearHigh).        Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.High).            Build(Priority.ModeratelyHigh));
                                                        
                    //X VERY FAR
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.ExtremelyLow).    Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.NearLow).         Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.NearHigh).        Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.High).            Build(Priority.High));
                }

                // +++++++++++++++++++++++++ PASS CLEAR +++++++++++++++++++++++++++++++++
                { 
                    //X VERY NEAR
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.High).            Build(Priority.ModeratelyLow));
                                                          
                    //X MODERATELY NEAR                   
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearLow).         Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearHigh).        Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.High).            Build(Priority.ModeratelyLow));
                                                          
                    //X NEAR                              
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.NearLow).         Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.NearHigh).        Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.High).            Build(Priority.Medium));
                                                          
                    //X FAR                               
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.NearLow).         Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.NearHigh).        Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.High).            Build(Priority.ModeratelyHigh));
                                                          
                    //X VERY FAR                          
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.ExtremelyLow).    Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearLow).         Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearHigh).        Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.High).            Build(Priority.High));
                }

                // +++++++++++++++++++++++++ PASS VERY CLEAR +++++++++++++++++++++++++++++++++
                { 
                    //X VERY NEAR
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearLow).         Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearHigh).        Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.High).            Build(Priority.Medium));
                                                         
                    //X MODERATELY NEAR                  
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.High).            Build(Priority.Medium));
                                                          
                    //X NEAR                                
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.High).            Build(Priority.ModeratelyHigh));
                                                          
                    //X FAR                               
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.NearLow).         Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.NearHigh).        Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.High).            Build(Priority.ModeratelyHigh));
                                                          
                    //X VERY FAR                          
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.ExtremelyLow).    Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearLow).         Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearHigh).        Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.High).            Build(Priority.High));
                }
                
            }

             // ========================= SHOOT VERY CLEAR ================================
            { 
                // +++++++++++++++++++++++++ PASS BLOCKED +++++++++++++++++++++++++++++++++
                { 
                    // X VERY NEAR 
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.NearLow).         Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.NearHigh).        Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryNear).And().  Var(BallY.High).            Build(Priority.Low));
                                                          
                    //X MODERATELY NEAR                    
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearLow).         Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearHigh).        Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.High).            Build(Priority.Low));
                                                         
                    //X NEAR                              
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.ExtremelyLow).    Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.NearLow).         Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.NearHigh).        Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.Near).And().  Var(BallY.High).            Build(Priority.Low));
                                                          
                    //X FAR                               
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.NearLow).         Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.NearHigh).        Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.Far).And().  Var(BallY.High).            Build(Priority.ModeratelyHigh));
                                                         
                    //X VERY FAR                          
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.ExtremelyLow).    Build(Priority.Low));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.Blocked).And().    Var(BallX.VeryFar).And().  Var(BallY.High).            Build(Priority.Low));
                }

                // +++++++++++++++++++++++++ PASS CLEAR +++++++++++++++++++++++++++++++++
                { 
                    //X VERY NEAR
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryNear).And().  Var(BallY.High).            Build(Priority.ModeratelyLow));
                                                          
                    //X MODERATELY NEAR                   
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.High).            Build(Priority.ModeratelyLow));
                                                          
                    //X NEAR                              
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Near).And().  Var(BallY.High).            Build(Priority.ModeratelyLow));
                                                          
                    //X FAR                               
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.Far).And().  Var(BallY.High).            Build(Priority.Medium));
                                                          
                    //X VERY FAR                          
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyLow));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.Clear).And().   Var(Pass.Clear).And().    Var(BallX.VeryFar).And().  Var(BallY.High).            Build(Priority.ModeratelyLow));
                }

                // +++++++++++++++++++++++++ PASS VERY CLEAR +++++++++++++++++++++++++++++++++
                { 
                    //X VERY NEAR
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearLow).         Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.NearHigh).        Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryNear).And().  Var(BallY.High).            Build(Priority.Medium));
                                                         
                    //X MODERATELY NEAR                  
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearLow).         Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.NearHigh).        Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.ModeratelyNear).And().  Var(BallY.High).            Build(Priority.Medium));
                                                          
                    //X NEAR                                
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.NearLow).         Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.NearHigh).        Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Near).And().  Var(BallY.High).            Build(Priority.Medium));
                                                          
                    //X FAR                               
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.ExtremelyLow).    Build(Priority.Medium));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.NearLow).         Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.NearHigh).        Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.Far).And().  Var(BallY.High).            Build(Priority.Medium));
                                                          
                    //X VERY FAR                          
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.ExtremelyLow).    Build(Priority.ModeratelyHigh));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearLow).         Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.NearHigh).        Build(Priority.High));
                    listOfRules.Add(builder.    Var(Shoot.VeryClear).And().   Var(Pass.VeryClear).And().    Var(BallX.VeryFar).And().  Var(BallY.High).            Build(Priority.ModeratelyHigh));
                }
                
            }
            return listOfRules;
        }

        public float GetPriority(float sShoot, float sPass, float ballX, float ballY)
        {
            IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> fuzzified;
            IList<FuzzyValue<IResultFuzzyMember>> evaluated;

            var result = fls.Evaluate(new Dictionary<int, float>
            {
                {this.Shoot.Category, sShoot },
                {this.Pass.Category, sPass },
                {this.BallX.Category, ballX},
                {this.BallY.Category, ballY }
            }, out fuzzified, out evaluated);

            return result;
        }

    }
}
