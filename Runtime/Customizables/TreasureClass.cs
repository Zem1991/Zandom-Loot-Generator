using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZemReusables;

namespace ZandomLootGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Loot Generator/Treasure Class")]
    public class TreasureClass : ItemBasePicker
    {
        public new string name;
        public int levelRequired;
        public TreasureClass next;
        public TreasureParameters parameters;
        public TreasureOptions options;

        public override ItemBase Pick(SeededRandom seededRandom)
        {
            return options.Pick(seededRandom);
        }
    }
}
