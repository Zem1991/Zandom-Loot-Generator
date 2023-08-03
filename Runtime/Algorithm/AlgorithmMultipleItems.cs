using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Customizables;
using ZemReusables;

namespace ZandomLootGenerator.Algorithm
{
    public class AlgorithmMultipleItems
    {
        private StyleParameters StyleParameters { get; }
        public SeededRandom SeededRandom { get; }
        private MainTreasureClass MainTreasureClass { get; }

        public AlgorithmMultipleItems(StyleParameters styleParameters, SeededRandom seededRandom, MainTreasureClass mainTreasureClass)
        {
            StyleParameters = styleParameters;
            SeededRandom = seededRandom;
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
                if (attempts >= StyleParameters.AttemptsMaximum)
                {
                    Debug.LogError("Too many attempts at generating multiple rewards.");
                    break;
                }
                attempts++;
                AlgorithmSingleItem algorithm = new(StyleParameters, SeededRandom, MainTreasureClass);
                ItemReward reward = algorithm.Process();
                result.Add(reward);
            }
            return result;
        }
    }
}
