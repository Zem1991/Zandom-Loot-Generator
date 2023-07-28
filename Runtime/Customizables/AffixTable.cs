using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Loot Generator/Affix Table")]
    public class AffixTable : ScriptableObject
    {
        public List<AffixBase> affixes = new();

        public AffixBase Pick()
        {
            System.Random random = new();
            int index = random.Next(affixes.Count);
            return affixes[index];
        }
    }
}
