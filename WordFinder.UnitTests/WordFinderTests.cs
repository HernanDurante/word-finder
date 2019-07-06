using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WordFinder.UnitTests
{
    [TestFixture]
    public class WordFinderTests
    {
        private IEnumerable<string> _testMatrix;

        [SetUp]
        public void SetUp()
        {
            _testMatrix = new[] {
            "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"
          };
        }

        [Test]
        public void Find_WhenMatchesFound_ReturnTopTenListOfMatchesOrderedByNumberOfMatches()
        {
            WordFinder finder = new WordFinder(_testMatrix);

            IEnumerable<string> result = finder.Find(new[] { "Messi", "Jordan", "Federer", "Ginobili", "Iverson", "Bird", "Ronaldo", "Ewing", "Stockton", "Maradona", "Cruyff", "Kobe", "James" });

            Assert.That(result, Is.Unique);
            Assert.That(result, Is.EquivalentTo(new[] { "Messi", "Jordan", "Federer", "Bird", "Ewing", "Stockton", "Maradona", "Cruyff", "Kobe", "Ginobili" }));
        }

        [Test]
        public void Find_WhenNoMatchesFound_ReturnEmptyList()
        {
            WordFinder finder = new WordFinder(_testMatrix);
            IEnumerable<string> result = finder.Find(new[] { "Lauda", "Ronaldo", "Hewwit", "Iverson" });
            Assert.That(result, Is.Empty);
        }
    }
}
