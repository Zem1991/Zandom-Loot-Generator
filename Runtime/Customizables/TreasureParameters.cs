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
        //public TreasureOptions treasureOptions;

        //public TreasureParameters(int minimumDrops, int maximumDrops, RarityWeights rarityWeights, TreasureOptions treasureOptions)
        //{
        //    this.minimumDrops = minimumDrops;
        //    this.maximumDrops = maximumDrops;
        //    this.rarityWeights = rarityWeights;
        //    this.treasureOptions = treasureOptions;
        //}

        public TreasureParameters Combine(TreasureParameters other)
        {
            TreasureParameters result = new()
            {
                minimumDrops = Mathf.Max(minimumDrops, other.minimumDrops),
                maximumDrops = Mathf.Max(maximumDrops, other.maximumDrops),
                rarityWeights = rarityWeights.Combine(other.rarityWeights),
                //treasureOptions = other.treasureOptions,
            };
            return result;
        }
    }
}
