using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Customizables
{
    //[CreateAssetMenu(menuName = "Zandom Loot Generator/Item Base")]
    [System.Serializable]
    public class ItemBase// : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private int level;
        [SerializeField] private bool noRarity;
        //[SerializeField] private List<string> categories;
        //[SerializeField] private List<string> rarities;

        public string Name { get => name; }
        public int Level { get => level; }
        public bool NoRarity { get => noRarity; }
        //public List<string> Categories { get => categories; }
        //public List<string> Rarities { get => rarities; }
    }
}
