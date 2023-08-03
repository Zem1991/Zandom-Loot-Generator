using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Algorithm;
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
        [SerializeField] private TreasureClass tclv0;
        [SerializeField] private TreasureClass tclv5;
        [SerializeField] private TreasureClass tclv10;

        [Header("Runtime")]
        [SerializeField] private TreasureClass currentTC;
        [SerializeField] private int playerLevel;

        private void Start()
        {
            InvokeRepeating(nameof(RaisePlayerLevel), 0F, 2F);
            InvokeRepeating(nameof(SelectTreasureClass), 0F, 2F);
            InvokeRepeating(nameof(GenerateItem), 0F, 0.5F);
        }

        private void RaisePlayerLevel()
        {
            playerLevel++;
            Debug.Log($"Player Level increased to {playerLevel}");
        }

        private void SelectTreasureClass()
        {
            if (playerLevel >= 10)
                currentTC = tclv10;
            else if (playerLevel >= 10)
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
