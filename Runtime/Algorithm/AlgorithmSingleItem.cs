using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Customizables;
using ZemReusables;

namespace ZandomLootGenerator.Algorithm
{
    public class AlgorithmSingleItem
    {
        private StyleParameters StyleParameters { get; }
        public SeededRandom SeededRandom { get; }
        private MainTreasureClass MainTreasureClass { get; }

        public AlgorithmSingleItem(StyleParameters styleParameters, SeededRandom seededRandom, MainTreasureClass mainTreasureClass)
        {
            StyleParameters = styleParameters;
            SeededRandom = seededRandom;
            MainTreasureClass = mainTreasureClass;
        }

        public ItemReward Process()
        {
            ItemBase item = PickItem();
            if (item == null)
            {
                //Debug.LogWarning("A null ItemBase was picked, so current ItemReward is also null.");
                return null;
            }
            RarityTier rarity = PickRarity(item);
            ItemBase unique = null;
            List<AffixBase> affixes = new();
            if (rarity == StyleParameters.UniqueRarity)
            {
                unique = SelectUniqueItem(item);
                if (unique == null)
                {
                    rarity = StyleParameters.RareRarity;
                }
            }
            if (rarity != StyleParameters.CommonRarity && unique == null)
            {
                affixes = PickAffixes(item, rarity);
            }
            ItemReward result = new()
            {
                item = unique ?? item,
                rarity = rarity,
                affixes = affixes,
            };
            return result;
        }

        private ItemBase PickItem()
        {
            ItemBase result = MainTreasureClass.Options.Pick(SeededRandom);
            return result;
        }

        private RarityTier PickRarity(ItemBase item)
        {
            RarityPicker rarityPicker = new(StyleParameters, SeededRandom);
            if (item.NoRarity) return rarityPicker.NoRarity();
            return rarityPicker.Pick();
            //RarityTier result = MainTreasureClass.Parameters.rarityWeights.Pick(StyleParameters, SeededRandom, item);
            //return result;
        }

        private ItemBase SelectUniqueItem(ItemBase item)
        {
            return null;
        }

        private List<AffixBase> PickAffixes(ItemBase item, RarityTier rarity)
        {
            return new();
        }
    }
}
