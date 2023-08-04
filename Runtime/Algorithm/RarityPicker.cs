using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Customizables;
using ZemReusables;

namespace ZandomLootGenerator.Algorithm
{
    public class RarityPicker
    {
        public RarityPicker(StyleParameters styleParameters, RarityWeights rarityWeights, SeededRandom seededRandom)
        {
            StyleParameters = styleParameters;
            RarityWeights = rarityWeights;
            SeededRandom = seededRandom;
        }

        public StyleParameters StyleParameters { get; }
        public RarityWeights RarityWeights { get; }
        public SeededRandom SeededRandom { get; }

        public float LastRoll { get; private set; }

        public RarityTier Pick()
        {
            bool unique = RollUnique();
            if (unique) return StyleParameters.UniqueRarity;
            bool rare = RollRare();
            if (rare) return StyleParameters.RareRarity;
            bool magic = RollMagic();
            if (magic) return StyleParameters.MagicRarity;
            return NoRarity();
        }

        public RarityTier NoRarity()
        {
            return StyleParameters.CommonRarity;
        }

        private bool RollUnique()
        {
            float rollValue = RarityWeights.Unique;
            return Roll(rollValue);
        }

        private bool RollRare()
        {
            float rollValue = Mathf.Min(LastRoll, RarityWeights.Rare);
            return Roll(rollValue);
        }

        private bool RollMagic()
        {
            float rollValue = Mathf.Min(LastRoll, RarityWeights.Magic);
            return Roll(rollValue);
        }

        private bool Roll(float rollValue)
        {
            LastRoll = SeededRandom.NextFloat() * rollValue;
            return LastRoll <= 0;
        }
    }
}
