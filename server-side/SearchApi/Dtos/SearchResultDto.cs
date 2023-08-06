namespace SearchApi.Dtos
{
    public class SearchResultDto
    {
        public int CurrentPage { get; set; }
        public int NumOfPages { get; set; }
        public int RelevantDocumentsCount { get; set; }
        public List<DocumentResponseDto> Documents { get; set; } = new List<DocumentResponseDto>();
    }
}
