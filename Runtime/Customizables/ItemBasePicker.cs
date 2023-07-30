using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZemReusables;

namespace ZandomLootGenerator.Customizables
{
    public abstract class ItemBasePicker : ScriptableObject
    {
        public abstract ItemBase Pick(SeededRandom seededRandom);
    }
}
