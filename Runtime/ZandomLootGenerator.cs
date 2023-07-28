using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Algorithm;
using ZandomLootGenerator.Customizables;

namespace ZandomLootGenerator
{
    public class ZandomLootGenerator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private StyleParameters zandomParameters;

        public List<ItemReward> Generate(TreasureClass encounterTC, int playerLevel)
        {
            List<ItemReward> result = new();
            MainTreasureClass mtc = DefineMainTreasureClass(encounterTC, playerLevel);
            List<ItemReward> rewards = GenerateItemRewards(zandomParameters, mtc);
            result.AddRange(rewards);
            return result;
        }

        private MainTreasureClass DefineMainTreasureClass(TreasureClass encounterTC, int playerLevel)
        {
            MainTreasureClass result = new(encounterTC, playerLevel);
            return result;
        }

        private List<ItemReward> GenerateItemRewards(StyleParameters styleParameters, MainTreasureClass mainTreasureClass)
        {
            AlgorithmMultipleItems algorithm = new(styleParameters, mainTreasureClass);
            List<ItemReward> result = algorithm.Process();
            return result;
        }
    }
}
