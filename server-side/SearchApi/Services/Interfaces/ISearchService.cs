using SearchApi.Dtos;

namespace SearchApi.Services.Interfaces
{
    public interface ISearchService
    {
        SearchResultDto Search(string searchText, int pageSize, int pageNumber);
    }
}