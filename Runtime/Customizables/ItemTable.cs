using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Loot Generator/Item Table")]
    public class ItemTable : ItemBasePicker
    {
        public List<ItemBase> items = new();

        public override ItemBase Pick()
        {
            System.Random random = new();
            int index = random.Next(items.Count);
            return items[index];
        }
    }
}
