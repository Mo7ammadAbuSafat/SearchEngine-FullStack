using SearchApi.Repositories.Interfaces;

namespace SearchApi.Repositories.Implementaion
{
    public class IndexRepository : IIndexRepository
    {
        private Dictionary<string, List<int>> invertedIndex;

        public IndexRepository()
        {
            invertedIndex = new Dictionary<string, List<int>>();
        }

        public Dictionary<string, List<int>> GetIndex()
        {
            return invertedIndex;
        }

    }
}
