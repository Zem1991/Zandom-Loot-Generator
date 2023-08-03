using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLootGenerator.Customizables;

namespace ZandomLootGenerator.Algorithm
{
    public class MainTreasureClass
    {
        private TreasureClass EncounterTC { get; }
        private int PlayerLevel { get; }

        public List<TreasureClass> TreasureClasses { get; private set; }
        public TreasureClass CurrentTC { get; private set; }
        public TreasureParameters Parameters { get; private set; }
        public TreasureOptions Options { get; private set; }

        public MainTreasureClass(TreasureClass encounterTC, int playerLevel)
        {
            EncounterTC = encounterTC;
            PlayerLevel = playerLevel;
            TreasureClasses = new()
            {
                encounterTC
            };
            CurrentTC = encounterTC;
            Parameters = encounterTC.parameters;
            Options = encounterTC.options;
            HandleCompatibility();
        }

        private void HandleCompatibility()
        {
            if (CheckLevels())
            {
                return;
            }
            TreasureClass nextTC = CurrentTC.next;
            CurrentTC = nextTC;
            if (nextTC == null)
            {
                return;
            }
            TreasureClasses.Add(nextTC);
            Parameters = Parameters.Combine(nextTC.parameters);
            Options = nextTC.options;
            HandleCompatibility();
        }

        private bool CheckLevels()
        {
            bool playerOk = PlayerLevel >= CurrentTC.levelRequired;
            //bool encounterOk = true;//encounterLevel >= currentTC.levelRequired;
            return playerOk;// && encounterOk;
        }
    }
}
