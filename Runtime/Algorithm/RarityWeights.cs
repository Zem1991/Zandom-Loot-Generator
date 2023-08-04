using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Customizables;
using ZemReusables;

namespace ZandomLootGenerator.Algorithm
{
    [System.Serializable]
    public class RarityWeights
    {
        [Tooltip("Number of entries should equal to number of rarity tiers defined in your Style Parameters object.")]
        [SerializeField] private List<int> weights = new();

        public RarityWeights(List<int> weights)
        {
            this.weights = weights;
        }
        
        public List<int> Weights { get => weights; }

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

        public string Pick(StyleParameters styleParameters, SeededRandom seededRandom, ItemBase item)
        {
            List<string> rarityTiers = styleParameters.RarityTiers;
            if (Weights.Count != rarityTiers.Count)
            {
                throw new System.Exception($"Rarity Tiers and Rarity Weights differ in count.");
            }
            Dictionary<string, float> options = new();
            for (int i = 0; i < Weights.Count; i++)
            {
                string forRarity = rarityTiers[i];
                //bool allowed = item.Rarities.Contains(forRarity);
                //if (!allowed) continue;
                float forWeight = Weights[i];
                options.Add(forRarity, forWeight);
            }
            WeightedListHelper weightedListHelper = new();
            KeyValuePair<string, float> kvPair = weightedListHelper.RandomPick(options, seededRandom, x => x.Value);
            string result = kvPair.Key;
            return result;
        }
    }
}
