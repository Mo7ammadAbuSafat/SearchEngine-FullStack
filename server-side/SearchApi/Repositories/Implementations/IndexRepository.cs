﻿using SearchApi.Repositories.Interfaces;

namespace SearchApi.Repositories.Implementations
{
    public class IndexRepository : IIndexRepository
    {
        private Dictionary<string, List<int>> invertedIndex = new Dictionary<string, List<int>>();
        public bool IsWithStemming { get; private set; }
        public bool IsAllowedFrequency { get; private set; }
        public string TokenizerType { get; private set; } = string.Empty;


        public void Set(Dictionary<string, List<int>> newInvertedIndex, bool isWithStemming, string tokenizerType, bool isAllowedFrequency)
        {
            invertedIndex = newInvertedIndex;
            IsWithStemming = isWithStemming;
            TokenizerType = tokenizerType;
            IsAllowedFrequency = isAllowedFrequency;
        }

        public Dictionary<string, List<int>> GetIndex()
        {
            return invertedIndex;
        }

        public bool GetIsWithStemming()
        {
            return IsWithStemming;
        }

        public string GetTokenizerType()
        {
            return TokenizerType;
        }

        public bool GetIsAllowedFrequency()
        {
            return IsAllowedFrequency;
        }

    }
}
