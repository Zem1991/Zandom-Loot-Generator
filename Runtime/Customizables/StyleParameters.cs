using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Loot Generator/Style Parameters")]
    public class StyleParameters : ScriptableObject
    {
        [Header("Rarity Options")]
        [SerializeField] private List<string> rarityTiers = new()
        {
            "Normal",
            "Magic",
            "Rare",
            "Unique",
        };
        [SerializeField] private int uniqueIndex = 3;
        [SerializeField] private int uniqueFailsafeIndex = 2;

        public List<string> RarityTiers { get => rarityTiers; }

        public string UniqueTier()
        {
            return RarityTiers[uniqueIndex];
        }

        public string UniqueFailsafeTier()
        {
            return RarityTiers[uniqueFailsafeIndex];
        }
    }
}
