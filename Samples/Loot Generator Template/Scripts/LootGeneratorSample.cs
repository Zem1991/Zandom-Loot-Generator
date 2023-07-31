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
        [Header("References")]
        [SerializeField] private ZandomLootGenerator zandomLootGenerator;

        [Header("Settings")]
        [SerializeField] private TreasureClass encounterTC;

        [Header("Runtime")]
        [SerializeField] private int playerLevel;
        [SerializeField] private SeededRandom seededRandom;

        private void Start()
        {
            InvokeRepeating(nameof(RaisePlayerLevel), 0.25F, 3F);
            InvokeRepeating(nameof(GenerateItem), 0.5F, 0.5F);
        }

        private void RaisePlayerLevel()
        {
            playerLevel++;
            Debug.Log($"Player Level increased to {playerLevel}");
        }

        private void GenerateItem()
        {
            List<ItemReward> itemRewards = zandomLootGenerator.Generate(seededRandom, encounterTC, playerLevel);
            foreach (var item in itemRewards)
            {
                //TODO: debug log the item names and stuff
                Debug.Log($"Player Level increased to {playerLevel}");
            }
        }
    }
}
