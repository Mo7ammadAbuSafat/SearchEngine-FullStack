using SearchApi.Repositories.Interfaces;

namespace SearchApi.Repositories.Implementaion
{
    public class DocumentRepository : IDocumentRepository
    {
        private Dictionary<int, string> documents;

        public DocumentRepository()
        {
            documents = new Dictionary<int, string>();
        }

        public Dictionary<int, string> GetDocuments()
        {
            return documents;
        }
    }
}
