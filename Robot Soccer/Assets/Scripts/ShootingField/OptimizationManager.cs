using Assets.Scripts.FuzzyLogic.RobotMovement.FuzzySystems.Shooting;
using EvolutionaryAlgorithms.Genetic;
using EvolutionaryAlgorithms.Genetic.Generic;
using EvolutionaryAlgorithms.Genetic.Generic.Crossover;
using EvolutionaryAlgorithms.Genetic.Generic.Selection;
using FuzzyLogicSystems.Core.Generic.RuleBase;
using FuzzyLogicSystems.Core.Rules;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;

public class OptimizationManager : MonoBehaviour
{
    public string FilePath;

    public float TimeScale;

    public bool IsTrialRunning;
    public int TrialCount;
    public int GenerationCount;

    public int PopulationSize;
    public int GenerationLimit;
    public float MutationChance;

    private IList<EvaluationTreeRuleBase> leftRules;
    private IList<EvaluationTreeRuleBase> rightRules;

    private EvaluationTreeRuleBaseFactory OrganismFactory;
    private RuleCopier GeneCopier;
    private ISelectionMethod SelectionMethod;
    private ICrossoverMethod CrossoverMethod;
    private GeneticAlgorithm<EvaluationTreeRuleBase, Rule> GeneticAlgorithm;
    
    public GameObject Trial;
    private TrialController TrialController;

    public void Start()
    {
        //FilePath = "C:\\Users\\JKMT\\Desktop\\OptimizationShooting.txt";

        leftRules = new List<EvaluationTreeRuleBase>(PopulationSize);
        rightRules = new List<EvaluationTreeRuleBase>(PopulationSize);

        for (int i = 0; i < PopulationSize; i++)
        {
            leftRules.Add(FuzzyShootingUtil.CreateRandomEvaluationTreeRuleBase());
            rightRules.Add(FuzzyShootingUtil.CreateRandomEvaluationTreeRuleBase());
        }

        IsTrialRunning = false;
        TrialCount = 0;
        GenerationCount = 1;

        TrialController = Trial.GetComponent<TrialController>();

        OrganismFactory = new EvaluationTreeRuleBaseFactory(FuzzyShootingUtil.InputSets, FuzzyShootingUtil.TorqueSet);
        GeneCopier = new RuleCopier();

        SelectionMethod = new StochasticUniversalSamplingSelection(0.11f, 0.29f);
        CrossoverMethod = new UniformCrossover();

        GeneticAlgorithm = new GeneticAlgorithm<EvaluationTreeRuleBase, Rule>(SelectionMethod, CrossoverMethod, OrganismFactory, GeneCopier);
    }

    public void FixedUpdate()
    {
        Time.timeScale = TimeScale;

        if (!IsTrialRunning)
        {
            if (TrialCount < PopulationSize)
            {
                int index = TrialCount;

                TrialController.StartTrial(leftRules[index], rightRules[index]);
                IsTrialRunning = true;
            }
            else
            {
                using (var file = new StreamWriter(FilePath, true))
                    file.WriteLine(GenerationCount + "," + leftRules.Average(x => x.Fitness) + "," + leftRules.Max(x => x.Fitness) + "," + leftRules.Min(x => x.Fitness));

                Debug.Log("BREEDING!");
                leftRules = GeneticAlgorithm.BreedNewGeneration(leftRules, MutationChance);
                rightRules = GeneticAlgorithm.BreedNewGeneration(rightRules, MutationChance);
                Debug.Log("Finished Breeding!");

                TrialCount = 0;
                GenerationCount++;

                if (GenerationCount >= GenerationLimit)
                    TimeScale = 0;
            }
        }
    }
    
    public void TrialFinished(EvaluationTreeRuleBase left, EvaluationTreeRuleBase right)
    {
        TrialCount++;
        IsTrialRunning = false;
    }
}
