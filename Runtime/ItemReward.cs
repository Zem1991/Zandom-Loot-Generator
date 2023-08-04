using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Customizables;

namespace ZandomLootGenerator.Algorithm
{
    public class ItemReward
    {
        public ItemBase item;
        public RarityTier rarity;
        //public ItemBase unique;
        public List<AffixBase> affixes;

        public override string ToString()
        {
            string color = ColorUtility.ToHtmlStringRGBA(rarity.Color);
            string result = $"<color=#{color}>{item.Name} [{rarity.Name}]</color>";
            return result;
        }
    }
}
