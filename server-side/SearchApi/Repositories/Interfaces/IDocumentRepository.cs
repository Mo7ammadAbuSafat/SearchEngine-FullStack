namespace SearchApi.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Dictionary<int, string> GetDocuments();
        void Set(Dictionary<int, string> newDocuments);
    }
}