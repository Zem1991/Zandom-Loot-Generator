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
        [SerializeField] private List<RarityTier> rarityTiers = new()
        {
            new RarityTier("Common", Color.white),
            new RarityTier("Magic", Color.cyan),
            new RarityTier("Rare", Color.green),
            new RarityTier("Unique", Color.yellow),
        };
        [SerializeField] private int uniqueIndex = 3;
        [SerializeField] private int uniqueFailsafeIndex = 2;

        public int AttemptsMaximum { get => attemptsMaximum; }
        public List<RarityTier> RarityTiers { get => rarityTiers; }

        public RarityTier UniqueTier()
        {
            return RarityTiers[uniqueIndex];
        }

        public RarityTier UniqueFailsafeTier()
        {
            return RarityTiers[uniqueFailsafeIndex];
        }
    }
}
