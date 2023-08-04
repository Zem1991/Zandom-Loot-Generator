using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Customizables;

namespace ZandomLootGenerator.Algorithm
{
    public class ItemReward
    {
        public ItemBase item;
        public string rarity;
        //public ItemBase unique;
        public List<AffixBase> affixes;

        public override string ToString()
        {
            //TODO: affixes
            return $"{item.Name} [{rarity}]";
        }
    }
}
