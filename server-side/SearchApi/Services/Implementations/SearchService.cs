using SearchApi.Dtos;
using SearchApi.Repositories.Interfaces;
using SearchApi.Services.Interfaces;
using SearchApi.Utills;

namespace SearchApi.Services.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly IIndexRepository invertedIndexRepository;
        private readonly IDocumentRepository documentRepository;

        public SearchService(IIndexRepository invertedIndexRepository, IDocumentRepository documentRepository)
        {
            this.invertedIndexRepository = invertedIndexRepository;
            this.documentRepository = documentRepository;
        }

        public SearchResultDto Search(string searchText, int pageSize, int pageNumber)
        {
            var tokenizerType = invertedIndexRepository.GetTokenizerType();
            var terms = EnglishTokenizer.Tokenize(searchText, tokenizerType);

            var isWithStemming = invertedIndexRepository.GetIsWithStemming();
            if (isWithStemming)
            {
                terms = terms.Select(term => EnglishStemmer.Stem(term)).ToArray();
            }

            var invertedIndex = invertedIndexRepository.GetIndex();
            var documentScores = new Dictionary<int, int>();
            foreach (string term in terms)
            {
                if (invertedIndex.ContainsKey(term))
                {
                    var postings = invertedIndex[term];
                    foreach (var documentKey in postings)
                    {
                        if (documentScores.ContainsKey(documentKey))
                        {
                            documentScores[documentKey]++;
                        }
                        else
                        {
                            documentScores[documentKey] = 1;
                        }
                    }
                }
            }

            var relevantDocumentsCount = documentScores.Count();
            var numOfPages = Math.Ceiling(relevantDocumentsCount / (pageSize * 1f));

            Dictionary<int, string> documents = documentRepository.GetDocuments();
            var resultDocuments = documentScores.OrderByDescending(k => k.Value)
                                                  .Select(k => new DocumentResponseDto { Score = k.Value, Text = documents[k.Key] })
                                                  .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                                                  .ToList();

            return new SearchResultDto()
            {
                Documents = resultDocuments,
                CurrentPage = pageNumber,
                NumOfPages = (int)numOfPages,
                RelevantDocumentsCount = relevantDocumentsCount,
            };
        }

    }
}
