using SearchApi.Repositories.Interfaces;

namespace SearchApi.Repositories.Implementations
{
    public class DocumentRepository : IDocumentRepository
    {
        private Dictionary<int, string>? documents;

        public Dictionary<int, string> GetDocuments()
        {
            return documents;
        }

        public void Set(Dictionary<int, string> newDocuments)
        {
            documents = newDocuments;
        }
    }
}
