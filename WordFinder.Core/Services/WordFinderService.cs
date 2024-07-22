using WordFinder.Core.Interfaces;
using System.Linq;

namespace WordFinder.Core.Services
{
    public class WordFinderService : IWordFinderService
    {
        public IEnumerable<string> Find(
            IEnumerable<string> matrix,
            IEnumerable<string> wordStream)
        {
            WordFinder wordFinder = new WordFinder(matrix);
            return wordFinder.Find(wordStream);
        }
    }
}
