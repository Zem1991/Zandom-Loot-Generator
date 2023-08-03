using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZemReusables;

namespace ZandomLootGenerator.Customizables
{
    [System.Serializable]
    public class TreasureOptions : PseudoDictionaryScriptableObject<ItemBasePicker, int>
    {
        public ItemBase Pick(SeededRandom seededRandom)
        {
            int count = items.Count;
            if (count <= 0) return null;
            Dictionary<ItemBasePicker, float> pickers = new();
            foreach (var item in items)
            {
                ItemBasePicker forItem = item.key;
                float forWeight = item.value;
                pickers.Add(forItem, forWeight);
            }
            WeightedListHelper weightedListHelper = new();
            KeyValuePair<ItemBasePicker, float> kvPair = weightedListHelper.RandomPick(pickers, seededRandom, x => x.Value);
            ItemBasePicker picker = kvPair.Key;
            return picker.Pick(seededRandom);
        }
    }
}
