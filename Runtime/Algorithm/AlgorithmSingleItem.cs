using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Customizables;

namespace ZandomLootGenerator.Algorithm
{
    public class AlgorithmSingleItem
    {
        private StyleParameters StyleParameters { get; }
        private MainTreasureClass MainTreasureClass { get; }

        public AlgorithmSingleItem(StyleParameters styleParameters, MainTreasureClass mainTreasureClass)
        {
            StyleParameters = styleParameters;
            MainTreasureClass = mainTreasureClass;
        }

        public ItemReward Process()
        {
            ItemBase item = PickItem();
            string rarity = PickRarity(item);
            ItemBase unique = null;
            List<AffixBase> affixes = new();
            if (rarity == StyleParameters.UniqueTier())
            {
                unique = SelectUniqueItem(item);
                if (unique == null)
                {
                    rarity = StyleParameters.UniqueFailsafeTier();
                }
            }
            if (unique == null)
            {
                affixes = PickAffixes(item, rarity);
            }
            ItemReward result = new()
            {
                item = unique != null ? unique : item,
                rarity = rarity,
                affixes = affixes,
            };
            return result;
        }

        private ItemBase PickItem()
        {
            ItemBase result = MainTreasureClass.Options.Pick();
            return result;
        }

        private string PickRarity(ItemBase item)
        {
            string result = MainTreasureClass.Parameters.rarityWeights.Pick(StyleParameters, item);
            return result;
        }

        private ItemBase SelectUniqueItem(ItemBase item)
        {
            return null;
        }

        private List<AffixBase> PickAffixes(ItemBase item, string rarity)
        {
            return new();
        }
    }
}
