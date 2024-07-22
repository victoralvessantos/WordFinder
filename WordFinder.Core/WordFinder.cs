using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordFinder.Core
{
    public class WordFinder
    {
        private IEnumerable<string> _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            if (!wordStream.Any())
                return Enumerable.Empty<string>();

            if (!_matrix.Any())
                return Enumerable.Empty<string>();

            var groupedWordStream = wordStream.Distinct();
            var verticalWords = new List<string>();

            var wordsFoundDictionary = new Dictionary<string, int>();

            for (int contRows = 0; contRows < _matrix.Count(); contRows++)
            {
                var row = _matrix.ElementAt(contRows);

                SetVerticalWords(
                    verticalWords,
                    row);

                SearchWords(
                    groupedWordStream,
                    wordsFoundDictionary,
                    row);
            }

            foreach (var verticalWord in verticalWords)
            {
                SearchWords(
                    groupedWordStream,
                    wordsFoundDictionary,
                    verticalWord);
            }

            if (wordsFoundDictionary.Count == 0)
                return Enumerable.Empty<string>();

            var top10WordsFound = wordsFoundDictionary
                .OrderByDescending(i => i.Value)
                .Take(10)
                .Select(i => i.Key)
                .AsEnumerable();

            return top10WordsFound;
        }

        private void SetVerticalWords(
            List<string> verticalWords,
            string row)
        {
            for (int contCollumn = 0; contCollumn < row.Length; contCollumn++)
            {
                var letter = row.Substring(contCollumn, 1);
                var collumnLetter = verticalWords.ElementAtOrDefault(contCollumn);

                if (string.IsNullOrEmpty(collumnLetter))
                    verticalWords.Add(letter);
                else
                    verticalWords[contCollumn] = string.Concat(
                        collumnLetter, 
                        letter);
            }
        }

        private void SearchWords(
            IEnumerable<string> wordStream,
            Dictionary<string, int> wordsFoundDictionary,
            string stringFromMatrix)
        {
            foreach (var wordToBeSearched in wordStream)
            {
                var matches = Regex.Matches(stringFromMatrix, wordToBeSearched).Count;
                if (matches > 0)
                {
                    var wordWxistsOnDictionary = wordsFoundDictionary.TryGetValue(
                        wordToBeSearched, 
                        out int contWord);

                    if (wordWxistsOnDictionary)
                        wordsFoundDictionary[wordToBeSearched] = contWord + matches;
                    else
                        wordsFoundDictionary.Add(
                            wordToBeSearched, 
                            matches);
                }
            }
        }
    }
}
