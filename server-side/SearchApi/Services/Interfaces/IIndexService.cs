namespace SearchApi.Services.Interfaces
{
    public interface IIndexService
    {
        Task BuildInvertedIndexByCSVFile(IFormFile file, string tokenizerType, bool isWithStemming);
    }
}