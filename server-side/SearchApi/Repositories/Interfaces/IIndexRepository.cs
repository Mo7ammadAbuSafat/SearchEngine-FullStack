namespace SearchApi.Repositories.Interfaces
{
    public interface IIndexRepository
    {
        Dictionary<string, List<int>> GetIndex();
    }
}