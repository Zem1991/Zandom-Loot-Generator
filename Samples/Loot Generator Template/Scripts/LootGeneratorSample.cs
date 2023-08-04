using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Customizables;
using ZemReusables;

namespace ZandomLootGenerator.Samples.LootGeneratorSample
{
    public class LootGeneratorSample : MonoBehaviour
    {
        private SeededRandom seededRandom;

        [Header("References")]
        [SerializeField] private ZandomLootGenerator zandomLootGenerator;

        [Header("Settings")]
        [SerializeField] private string seed;
        [SerializeField] private TreasureClass tclv0;
        [SerializeField] private TreasureClass tclv5;
        [SerializeField] private TreasureClass tclv10;

        [Header("RNG Seed")]
        [SerializeField] private string currentSeed;
        [SerializeField] private int currentSeedInt;

        [Header("Runtime")]
        [SerializeField] private TreasureClass currentTC;
        [SerializeField] private int playerLevel;

        private void Awake()
        {
            seededRandom = new(seed);
            currentSeed = seededRandom.Seed;
            currentSeedInt = seededRandom.SeedInt;
        }

        private void Start()
        {
            InvokeRepeating(nameof(RaisePlayerLevel), 0F, 2F);
            InvokeRepeating(nameof(GenerateItem), 0F, 0.5F);
        }

        private void RaisePlayerLevel()
        {
            playerLevel++;
            Debug.Log($"Player Level increased to {playerLevel}");
            SelectTreasureClass();
        }

        private void SelectTreasureClass()
        {
            if (playerLevel >= 10)
                currentTC = tclv10;
            else if (playerLevel >= 5)
                currentTC = tclv5;
            else
                currentTC = tclv0;
        }

        private void GenerateItem()
        {
            //List<ItemReward> itemRewards = zandomLootGenerator.Generate(seededRandom, encounterTC, playerLevel);
            zandomLootGenerator.Generate(seededRandom, currentTC, playerLevel);
        }
    }
}
