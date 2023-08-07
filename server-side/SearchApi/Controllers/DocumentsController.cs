using Microsoft.AspNetCore.Mvc;
using SearchApi.Services.Interfaces;

namespace SearchApi.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IIndexService indexService;
        private readonly ISearchService searchService;
        public DocumentsController(IIndexService indexService, ISearchService searchService)
        {
            this.indexService = indexService;
            this.searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> BuildInvertedIndexAndStoreDocuments(
            IFormFile file,
            string tokenizeType,
            bool isAllowedFrequency,
            bool isWithStemming)
        {
            await indexService.BuildInvertedIndexByCSVFile(file, tokenizeType, isAllowedFrequency, isWithStemming);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetRelevantDocuments(string searchText, int pageSize, int pageNumber)
        {
            var result = searchService.Search(searchText, pageSize, pageNumber);
            return Ok(result);
        }
    }
}
