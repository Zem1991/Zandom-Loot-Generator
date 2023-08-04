using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Customizables
{
    [System.Serializable]
    public class RarityTier
    {
        [SerializeField] private string name;
        [SerializeField] private Color color;

        public RarityTier(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public string Name { get => name; private set => name = value; }
        public Color Color { get => color; private set => color = value; }
    }
}
