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

        public override ItemBase Pick(SeededRandom seededRandom)
        {
            //TODO: include a No Item option?
            Dictionary<ItemBasePicker, float> options = new();
            for (int i = 0; i < references.Count; i++)
            {
                ItemBasePicker forItem = references[i];
                float forWeight = 1F;
                options.Add(forItem, forWeight);
            }
            WeightedListHelper weightedListHelper = new();
            KeyValuePair<ItemBasePicker, float> kvPair = weightedListHelper.RandomPick(options, seededRandom, x => x.Value);
            ItemBasePicker picker = kvPair.Key;
            return picker.Pick(seededRandom);
        }
    }
}
