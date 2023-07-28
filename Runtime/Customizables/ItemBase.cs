using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Loot Generator/Item Base")]
    public class ItemBase : ScriptableObject
    {
        public new string name;
        public List<string> categories;
        public List<string> rarities;
    }
}
