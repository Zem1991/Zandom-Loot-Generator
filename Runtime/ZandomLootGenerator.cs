using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Algorithm;
using ZandomLootGenerator.Customizables;
using ZemReusables;

namespace ZandomLootGenerator
{
    public class ZandomLootGenerator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private StyleParameters zandomParameters;

        [Header("Settings")]
        [SerializeField] private string seed = null;
        [SerializeField][Min(1)] private int maxAttempts = 10;

        [Header("RNG Runtime")]
        [SerializeField] private string currentSeed;
        [SerializeField] private int currentSeedInt;
        [SerializeField] private SeededRandom seededRandom;

        public StyleParameters ZandomParameters => zandomParameters;

        public string Seed => seed;
        public int MaxAttempts => maxAttempts;

        public string CurrentSeed { get => currentSeed; private set => currentSeed = value; }
        public int CurrentSeedInt { get => currentSeedInt; private set => currentSeedInt = value; }
        public SeededRandom SeededRandom { get => seededRandom; private set => seededRandom = value; }

        public void Awake()
        {
            SeededRandom = new(Seed);
            CurrentSeed = SeededRandom.Seed;
            CurrentSeedInt = SeededRandom.SeedInt;
        }

        public List<ItemReward> Generate(SeededRandom seededRandom, TreasureClass encounterTC, int playerLevel)
        {
            List<ItemReward> result = new();
            MainTreasureClass mtc = DefineMainTreasureClass(encounterTC, playerLevel);
            List<ItemReward> rewards = GenerateItemRewards(zandomParameters, seededRandom, mtc);
            result.AddRange(rewards);
            return result;
        }

        private MainTreasureClass DefineMainTreasureClass(TreasureClass encounterTC, int playerLevel)
        {
            MainTreasureClass result = new(encounterTC, playerLevel);
            //TODO: at StyleParameters, add a failsafe Treasure Class to be used when no MTC can be created from the desired TC
            return result;
        }

        private List<ItemReward> GenerateItemRewards(StyleParameters styleParameters, SeededRandom seededRandom, MainTreasureClass mainTreasureClass)
        {
            AlgorithmMultipleItems algorithm = new(styleParameters, seededRandom, mainTreasureClass);
            List<ItemReward> rewards = algorithm.Process();
            string mtcDebug = MainTreasureClassDebugMessage(mainTreasureClass);
            string rewardDebug = ItemRewardsDebugMessage(rewards);
            Debug.Log($"{mtcDebug}\n{rewardDebug}");
            return rewards;
        }

        private string MainTreasureClassDebugMessage(MainTreasureClass mainTreasureClass)
        {
            string currentTC = $"{mainTreasureClass.CurrentTC.name}";
            string minimumDrops = $"{mainTreasureClass.Parameters.minimumDrops}";
            string maximumDrops = $"{mainTreasureClass.Parameters.maximumDrops}";
            return $"Main Treasure Class based on {currentTC} ({minimumDrops} min, {maximumDrops} max)";
        }

        private string ItemRewardsDebugMessage(List<ItemReward> rewards)
        {
            string allRewardsNames = string.Join(", ", rewards);
            return $"Loot dropped: {allRewardsNames}";
        }
    }
}
