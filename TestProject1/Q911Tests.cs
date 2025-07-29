using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using static ConsArrays.Program;

namespace TestArraysIO
{
    [TestFixture]
    public class Q911Tests
    {
        /// <summary>
        /// Feeds the given inputs (one per ReadLine) into Q911() and returns all console output.
        /// </summary>
        private string RunWithInput(params string[] inputs)
        {
            var inData = string.Join(Environment.NewLine, inputs) + Environment.NewLine;
            using var reader = new StringReader(inData);
            using var writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);

            Q911();

            return writer.ToString();
        }

        [Test]
        public void SampleCase_ShouldMatchExpectedValuesAndIncludeExcellent()
        {
            // Arrange: nine high grades and one low (50)
            var inputs = new[]
            {
                "95","95","95","100","100","100","100","100","100","50"
            };

            // Act
            var output = RunWithInput(inputs);

            // Filter out any prompts
            var resultLines = output
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Where(l => !l.TrimStart().StartsWith("Enter"))
                .ToArray();

            // 1) Average
            Assert.That(resultLines[0], Is.EqualTo("Average: 93.50"));

            // 2) Above Average section
            var aboveSection = resultLines
                .Skip(1)
                .TakeWhile(l => !l.StartsWith("Below 60:"))
                .ToArray();
            var aboveCombined = string.Join(" ", aboveSection);
            Assert.That(aboveCombined.Trim(' ', ','),
                Is.EqualTo("Above Average: 95, 95, 95, 100, 100, 100, 100, 100, 100"));

            // 3) Below 60 line
            var belowIndex = 1 + aboveSection.Length;
            Assert.That(resultLines[belowIndex].Trim(' ', ','), Is.EqualTo("Below 60: 50"));

            // 4) Excellent
            Assert.That(resultLines.Last(), Is.EqualTo("Excellent"));
        }

        [Test]
        public void WhenAverageIsExactly90_ShouldNotPrintExcellent()
        {
            // Arrange: ten grades of 90 => avg 90.00
            var inputs = Enumerable.Repeat("90", 10).ToArray();

            // Act
            var output = RunWithInput(inputs);

            var resultLines = output
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Where(l => !l.TrimStart().StartsWith("Enter"))
                .ToArray();

            // Average line
            Assert.That(resultLines[0], Is.EqualTo("Average: 90.00"));

            // No "Excellent"
            Assert.That(resultLines.Any(l => l == "Excellent"), Is.False);
        }

        [Test]
        public void WhenNoGradesBelow60_ShouldOmitBelow60Section()
        {
            // Arrange: ten grades all above 60
            var inputs = new[]
            {
                "70","75","80","85","90","95","88","92","77","83"
            };

            // Act
            var output = RunWithInput(inputs);

            var resultLines = output
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Where(l => !l.TrimStart().StartsWith("Enter"))
                .ToArray();

            // Assert no "Below 60:" line appears
            Assert.That(resultLines.Count(l => l.StartsWith("Below 60:")), Is.EqualTo(0));
        }
    }
}
