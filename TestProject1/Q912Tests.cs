using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using static ConsArrays.Program;

namespace TestArraysIO
{
    [TestFixture]
    public class Q912Tests
    {
        // Helper to run MainQ911 with the given inputs and capture output
        private string RunWithInput(params string[] inputs)
        {
            var inStr = string.Join(Environment.NewLine, inputs) + Environment.NewLine;
            using var sr = new StringReader(inStr);
            using var sw = new StringWriter();
            Console.SetIn(sr);
            Console.SetOut(sw);

            Q912();

            return sw.ToString();
        }

        [Test]
        public void DuplicateName_ShouldPrintErrorMessageExactlyOnce()
        {
            // Arrange: first "Alice" accepted, second "Alice" → duplicate
            var inputs = new[]
            {
                "Alice",  // accepted
                "Alice",  // duplicate → should print error
                "Bob",
                "Carol",
                "Dave",
                "Eve",
                "Frank",
                "Grace",
                "Heidi"   // total 8 unique accepted
            };

            // Act
            var output = RunWithInput(inputs);

            // Assert
            var errorLines = output
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Count(line => line == "We cannot assign you to this class");

            Assert.That(errorLines, Is.EqualTo(1),
                "Expected exactly one duplicate‐name error message.");
        }

        [Test]
        public void AllUniqueNames_ShouldNotPrintAnyErrorMessage()
        {
            // Arrange: eight distinct names
            var inputs = new[]
            {
                "A","B","C","D","E","F","G","H"
            };

            // Act
            var output = RunWithInput(inputs);

            // Assert
            Assert.That(output.Contains("We cannot assign you to this class"),
                Is.False,
                "Did not expect any duplicate‐name error message.");
        }

        [Test]
        public void PromptsCount_ShouldMatchNumberOfAttempts()
        {
            // Arrange: include one duplicate so 9 attempts total
            var inputs = new[]
            {
                "X","X","Y","Z","U","V","W","T","S"
            };

            // Act
            var output = RunWithInput(inputs);

            // Count how many times the prompt appears
            var promptCount = output
                .Split(Environment.NewLine, StringSplitOptions.None)
                .Count(line => line.StartsWith("Enter a name:"));

            // We expect 9 prompts because one retry was needed for the duplicate
            Assert.That(promptCount, Is.EqualTo(9),
                "Prompt should be written once per each Console.ReadLine() attempt.");
        }
    }
}