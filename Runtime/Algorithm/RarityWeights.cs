using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Customizables;

namespace ZandomLootGenerator.Algorithm
{
    [System.Serializable]
    public class RarityWeights
    {
        [SerializeField] private List<int> weights = new();

        public RarityWeights(List<int> weights)
        {
            this.weights = weights;
        }

        public List<int> Weights { get => weights; }

        public string Pick(StyleParameters styleParameters, ItemBase item)
        {
            List<string> rarityTiers = styleParameters.RarityTiers;
            if (Weights.Count != rarityTiers.Count)
            {
                throw new System.Exception($"Rarity Tiers and Rarity Weights differ in count.");
            }
            //TODO: weighted selection based on what the item allows for rarity;
            return rarityTiers[0]; //return Rarity.NORMAL;
        }

        public RarityWeights Combine(RarityWeights other)
        {
            List<int> otherWeights = other.Weights;
            if (Weights.Count != otherWeights.Count)
            {
                throw new System.Exception($"This Rarity Weights and Other Rarity Weights differ in count.");
            }
            List<int> newWeights = new();
            for (int i = 0; i < Weights.Count; i++)
            {
                int weight = Mathf.Max(Weights[i], otherWeights[i]);
                newWeights.Add(weight);
            }
            RarityWeights result = new(newWeights);
            return result;
        }
    }
}
