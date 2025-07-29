using ConsArrays;

namespace TestArraysIO
{
    [TestFixture]
    public class MainQ2Test
    {

        // change this one value for all your students
        private const string TestInput = "2 7 7"; //guy
        //private const string TestInput = "5 23 11 100 46 231";

        // helper to run MainQ2 with given space-separated input
        private string[] RunAndCaptureLines(string spaceSeparatedInput)
        {
            // replace spaces with CRLF and append a final CRLF
            var formattedInput = spaceSeparatedInput.Replace(" ", "\r\n") + "\r\n";

            Console.SetIn(new StringReader(formattedInput));
            var output = new StringWriter();
            Console.SetOut(output);

            Program.MainQ2();

            return output
                .ToString()
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        [Test]
        public void ExcactlyOneLineContains2()
        {
            var lines = RunAndCaptureLines(TestInput);

            var countOf2 = lines.Count(l => l == "2");
            Assert.That(countOf2, Is.EqualTo(1),
                $"Expected exactly one '2' in output, but found {countOf2}. Full output was:{Environment.NewLine}{string.Join("|", lines)}");
        }

        [Test]
        public void OnlyOneLineOfOutput()
        {
            var lines = RunAndCaptureLines(TestInput);

            Assert.That(lines.Length, Is.EqualTo(1),
                $"Expected exactly 1 line of output, but got {lines.Length}. Output lines: {string.Join("|", lines)}");
        }

        [Test]
        public void OutputContainsAtLeastOne2()
        {
            var lines = RunAndCaptureLines(TestInput);

            Assert.That(lines, Does.Contain("2"),
                "Expected output to contain '2' on at least one line.");
        }
    }
}
