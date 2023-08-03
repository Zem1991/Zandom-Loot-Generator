using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZemReusables;

namespace ZandomLootGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Loot Generator/Item Table")]
    public class ItemTable : ItemBasePicker
    {
        public List<ItemBase> items = new();

        public override ItemBase Pick(SeededRandom seededRandom)
        {
            int count = items.Count;
            if (count <= 0) return null;
            int index = seededRandom.Range(0, count);
            return items[index];
        }
    }
}
