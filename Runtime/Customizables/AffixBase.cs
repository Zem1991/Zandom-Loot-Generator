using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Loot Generator/Affix Base")]
    public class AffixBase : ScriptableObject
    {
        public new string name;
        public List<string> categories;
        public List<string> rarities;
        public bool isPrefix;
    }
}
