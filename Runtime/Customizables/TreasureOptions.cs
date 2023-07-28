using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}
