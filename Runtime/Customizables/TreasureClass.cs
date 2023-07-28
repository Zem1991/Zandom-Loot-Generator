using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Loot Generator/Treasure Class")]
    public class TreasureClass : ScriptableObject
    {
        public new string name;
        public int levelRequired;
        public TreasureClass next;
        public TreasureParameters parameters;
        public TreasureOptions options;
    }
}
