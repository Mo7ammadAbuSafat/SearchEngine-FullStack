using Microsoft.AspNetCore.Mvc;
using SearchApi.Services.Interfaces;

namespace SearchApi.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IIndexService indexService;
        public DocumentsController(IIndexService indexService)
        {
            this.indexService = indexService;
        }

        [HttpPost]
        public async Task<IActionResult> BuildInvertedIndexAndStoreDocuments(IFormFile file, string tokenizeType, bool isWithStemming)
        {
            await indexService.BuildInvertedIndexByCSVFile(file, tokenizeType, isWithStemming);
            return NoContent();
        }
    }
}
