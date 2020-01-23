using FluentAssertions;
using Xunit;

namespace hello.ocr
{
    public class TesseractParserTest
    {
        [Fact]
        public void ShouldParse()
        {
            var fileName = "cicero_en.png";
            using var parser = new TesseractParser();

            using var page = parser.Parse(fileName);
            var text = page.GetText();
            text.Should().StartWith("But I must expla");
        }
    }
}
