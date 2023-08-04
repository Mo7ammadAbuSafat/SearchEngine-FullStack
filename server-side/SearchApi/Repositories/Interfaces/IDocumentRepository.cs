namespace SearchApi.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Dictionary<int, string> GetDocuments();
    }
}