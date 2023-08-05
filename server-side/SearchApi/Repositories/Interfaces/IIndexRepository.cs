namespace SearchApi.Repositories.Interfaces
{
    public interface IIndexRepository
    {
        Dictionary<string, List<int>> GetIndex();
        void Set(Dictionary<string, List<int>> newInvertedIndex);
    }
}