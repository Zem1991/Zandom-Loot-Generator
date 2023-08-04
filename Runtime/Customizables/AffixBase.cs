using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Customizables
{
    //[CreateAssetMenu(menuName = "Zandom Loot Generator/Affix Base")]
    [System.Serializable]
    public class AffixBase// : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private int level;
        //[SerializeField] private List<string> categories;
        //[SerializeField] private List<string> rarities;
        [SerializeField] private bool isPrefix;
    }
}
