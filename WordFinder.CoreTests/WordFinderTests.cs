using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordFinder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.Core.Tests
{
    [TestClass()]
    public class WordFinderTests
    {
        [TestMethod()]
        public void FindTest_EmptyWordStream()
        {
            var matrix = new List<string> { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };
            var expected = Enumerable.Empty<string>();

            var wordFinder = new WordFinder(matrix);
            var returnedValue = wordFinder.Find(expected);

            Assert.IsTrue(returnedValue == expected);
        }

        [TestMethod()]
        public void FindTest_NoWordsFoundInTheWordStream()
        {
            var matrix = new List<string> { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };
            var wordStream = new List<string> { "zzz", "xxx" };
            var expected = Enumerable.Empty<string>();

            var wordFinder = new WordFinder(matrix);
            var returnedValue = wordFinder.Find(wordStream);

            Assert.IsTrue(returnedValue == expected);
        }

        [TestMethod()]
        public void FindTest_RepeatedWordInTheWordStream()
        {
            var matrix = new List<string> { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };
            var wordStream = new List<string> { "cold", "wind", "snow", "chill", "chill" };
            var expected = new List<string> { "chill", "wind", "cold" };

            var wordFinder = new WordFinder(matrix);
            var returnedValue = wordFinder.Find(wordStream);

            Assert.IsTrue(returnedValue.SequenceEqual(expected));
        }

        [TestMethod()]
        public void FindTest_Top10MostRepeatedWordsInTheWordStream()
        {
            var matrix = new List<string>
            {
                "COMPUTERABCDEFG",
                "OCABIJKLMNOPQRS",
                "MONEXYZABCDEFGH",
                "PRAMPOWERIJKLMN",
                "UXYZABCDEFGHIJK",
                "THINKLMNOPQRSTU",
                "EVWXYZABCDEFGHI",
                "RIJKLMNOPQRSTUV",
                "ABCDEFGHIJKLMNO",
                "BCDEFGHIJKLMNOP",
                "SPARKLEGAMEHIJK",
                "GAMEIJKLMNOPQRS",
                "MNOPQRSTUVWXYZA",
                "POWERBCDEFGHIJK",
                "SPARKLEGAMETABL",
                "TABLETBVSFGHJJK",
                "OMEGALITHGDFGFI",
                "OGFDHGDMEGALITN",
                "LENTERTAINFSDFS",
                "CODEFSDKJFHSDKP",
                "FKSDJHFTHINKHJI",
                "TABLETBVSFGHJJR",
                "INSPIRECODEGHJE",
                "OMEGALITHGDFGFI",
                "LENTERTAINFSDFS"
            };

            var wordStream = new List<string>
            {
                "COMPUTER",
                "SPARKLE",
                "GAME",
                "POWER",
                "INSPIRE",
                "MEGALITH",
                "TABLET",
                "TOOL",
                "ENTERTAIN",
                "CODE",
                "THINK"
            };

            var expected = new List<string>
            {
                "GAME",
                "COMPUTER", 
                "POWER", 
                "THINK", 
                "SPARKLE",
                "TABLET",
                "MEGALITH",
                "ENTERTAIN",
                "CODE",
                "INSPIRE"
            };

            var wordFinder = new WordFinder(matrix);
            var returnedValue = wordFinder.Find(wordStream);

            Assert.IsTrue(returnedValue.SequenceEqual(expected));
        }
    }
}