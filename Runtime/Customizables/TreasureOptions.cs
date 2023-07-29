using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZemReusables;

namespace ZandomLootGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Loot Generator/Treasure Options")]
    public class TreasureOptions : ItemBasePicker
    {
        public List<ItemBasePicker> references = new();

        public override ItemBase Pick()
        {
            //TODO: include a No Item option
            //TODO: pick from weighted options
            System.Random random = new();
            int index = random.Next(references.Count);
            return references[index].Pick();
            Dictionary<string, float> options = new();
            for (int i = 0; i < Weights.Count; i++)
            {
                string forRarity = rarityTiers[i];
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
