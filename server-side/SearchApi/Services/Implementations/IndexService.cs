using SearchApi.Repositories.Interfaces;
using SearchApi.Services.Interfaces;
using SearchApi.Utills;

namespace SearchApi.Services.Implementations
{
    public class IndexService : IIndexService
    {
        private readonly IIndexRepository invertedIndexRepository;
        private readonly IDocumentRepository documentRepository;
        private readonly IFileService fileService;

        public IndexService(IIndexRepository invertedIndexRepository, IDocumentRepository documentRepository, IFileService fileService)
        {
            this.invertedIndexRepository = invertedIndexRepository;
            this.documentRepository = documentRepository;
            this.fileService = fileService;
        }

        public async Task BuildInvertedIndexByCSVFile(IFormFile file, string tokenizeType, bool isWithStemming)
        {
            string filePath = await fileService.StoreImageToLocalFolder(file);
            Dictionary<int, string> documents = CSVReader.Read(filePath);
            documentRepository.Set(documents);

            var invertedIndex = new Dictionary<string, List<int>>();

            foreach (var key in documents.Keys)
            {
                var terms = EnglishTokenizer.Tokenize(documents[key], tokenizeType);
                if (isWithStemming)
                {
                    terms = terms.Select(term => EnglishStemmer.Stem(term)).ToArray();
                }

                foreach (string term in terms)
                {
                    if (invertedIndex.ContainsKey(term))
                    {
                        invertedIndex[term].Add(key);
                    }
                    else
                    {
                        invertedIndex[term] = new List<int> { key };
                    }
                }
            }
            invertedIndexRepository.Set(invertedIndex);
        }
    }
}
