using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Customizables
{
    [CreateAssetMenu(menuName = "Zandom Loot Generator/Style Parameters")]
    public class StyleParameters : ScriptableObject
    {
        [Header("Safety Options")]
        [SerializeField] private int attemptsMaximum = 100;

        [Header("Rarity Options")]
        [SerializeField] private RarityTier commonRarity = new("Common", Color.white);
        [SerializeField] private RarityTier magicRarity = new("Magic", Color.cyan);
        [SerializeField] private RarityTier rareRarity = new("Magic", Color.green);
        [SerializeField] private RarityTier uniqueRarity = new("Unique", Color.yellow);

        public int AttemptsMaximum { get => attemptsMaximum; }
        public RarityTier CommonRarity { get => commonRarity; }
        public RarityTier MagicRarity { get => magicRarity; }
        public RarityTier RareRarity { get => rareRarity; }
        public RarityTier UniqueRarity { get => uniqueRarity; }
    }
}
