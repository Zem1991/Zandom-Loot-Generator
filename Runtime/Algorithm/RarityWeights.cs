using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLootGenerator.Algorithm
{
    [System.Serializable]
    public class RarityWeights
    {
        [SerializeField] private int magic = 25;
        [SerializeField] private int rare = 50;
        [SerializeField] private int unique = 100;

        public RarityWeights(int magic, int rare, int unique)
        {
            Magic = magic;
            Rare = rare;
            Unique = unique;
        }

        public int Magic { get => magic; private set => magic = value; }
        public int Rare { get => rare; private set => rare = value; }
        public int Unique { get => unique; private set => unique = value; }

        public RarityWeights Combine(RarityWeights other)
        {
            int magic = Mathf.Min(Magic, other.Magic);
            int rare = Mathf.Min(Rare, other.Rare);
            int unique = Mathf.Min(Unique, other.Unique);
            RarityWeights result = new(magic, rare, unique);
            return result;
        }
    }
}
