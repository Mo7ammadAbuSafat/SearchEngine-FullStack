using SearchApi.Repositories.Interfaces;

namespace SearchApi.Repositories.Implementations
{
    public class IndexRepository : IIndexRepository
    {
        private Dictionary<string, List<int>> invertedIndex;

        public void Set(Dictionary<string, List<int>> newInvertedIndex)
        {
            invertedIndex = newInvertedIndex;
        }

        public Dictionary<string, List<int>> GetIndex()
        {
            return invertedIndex;
        }

    }
}
