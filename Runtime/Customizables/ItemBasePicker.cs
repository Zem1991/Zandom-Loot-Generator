using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Customizables
{
    public abstract class ItemBasePicker : ScriptableObject
    {
        public abstract ItemBase Pick();
    }
}
