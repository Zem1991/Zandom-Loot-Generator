using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Customizables;

namespace ZandomLootGenerator.Algorithm
{
    public class AlgorithmMultipleItems
    {
        private StyleParameters StyleParameters { get; }
        private MainTreasureClass MainTreasureClass { get; }

        public AlgorithmMultipleItems(StyleParameters styleParameters, MainTreasureClass mainTreasureClass)
        {
            StyleParameters = styleParameters;
            MainTreasureClass = mainTreasureClass;
        }

        public List<ItemReward> Process()
        {
            int minimumDrops = MainTreasureClass.Parameters.minimumDrops;
            int maximumDrops = MainTreasureClass.Parameters.maximumDrops;
            int attempts = 0;
            List<ItemReward> result = new();
            while (result.Count < minimumDrops || attempts < maximumDrops)
            {
                AlgorithmSingleItem algorithm = new(StyleParameters, MainTreasureClass);
                ItemReward reward = algorithm.Process();
                result.Add(reward);
            }
            return result;
        }
    }
}
