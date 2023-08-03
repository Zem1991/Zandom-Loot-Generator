using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Algorithm;

namespace ZandomLootGenerator.Customizables
{
    [System.Serializable]
    public class TreasureParameters
    {
        public int minimumDrops;
        public int maximumDrops;
        public RarityWeights rarityWeights;

        public TreasureParameters Combine(TreasureParameters other)
        {
            TreasureParameters result = new()
            {
                minimumDrops = Mathf.Max(minimumDrops, other.minimumDrops),
                maximumDrops = Mathf.Max(maximumDrops, other.maximumDrops),
                rarityWeights = rarityWeights.Combine(other.rarityWeights),
            };
            return result;
        }
    }
}
