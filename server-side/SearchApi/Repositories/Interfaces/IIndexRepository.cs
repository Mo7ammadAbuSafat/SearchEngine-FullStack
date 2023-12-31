﻿namespace SearchApi.Repositories.Interfaces
{
    public interface IIndexRepository
    {
        Dictionary<string, List<int>> GetIndex();
        void Set(Dictionary<string, List<int>> newInvertedIndex, bool isWithStemming, string tokenizerType, bool isAllowedFrequency);
        bool GetIsWithStemming();
        string GetTokenizerType();
        bool GetIsAllowedFrequency();
    }
}