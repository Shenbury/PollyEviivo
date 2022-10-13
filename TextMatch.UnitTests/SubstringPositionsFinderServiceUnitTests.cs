using Microsoft.Extensions.Logging.Abstractions;
using TextMatch.Services;

namespace TextMatch.UnitTests
{
    public class SubstringPositionsFinderServiceUnitTests
    {
        private readonly ISubstringPositionsFinderService _service;
        public const string Text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";

        public SubstringPositionsFinderServiceUnitTests()
        {
            _service = new SubstringPositionsFinderService(new NullLogger<SubstringPositionsFinderService>());

        }

        [Theory]
        [InlineData("Polly", new int[] {1, 26, 51})]
        [InlineData("POLLY", new int[] { 1, 26, 51 })]
        [InlineData("PoLlY", new int[] { 1, 26, 51 })]
        [InlineData("polly", new int[] { 1, 26, 51 })]
        [InlineData("ll", new int[] { 3, 28, 53, 78, 82 })]
        [InlineData("Ll", new int[] { 3, 28, 53, 78, 82 })]
        [InlineData("LL", new int[] { 3, 28, 53, 78, 82 })]
        [InlineData("X", new int[] {})]
        [InlineData("x", new int[] {})]
        public void GivenInput_WhenServiceIsCalledWithSubtext_ReturnsPositions(string subText, int[] expectedResult)
        {
            var result = _service.GetPositionsOfSubString(subText, Text);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenPolx_WhenServiceIsCalled_ThrowsNullException()
        {
            string subText = "Polx";

            var result = _service.GetPositionsOfSubString(subText, null);

            Assert.Equal(new List<int>(), result);
        }

        [Theory]
        [InlineData("Yes", new int[] { 1 })]
        [InlineData("Yesser", new int[] { 1 })]
        [InlineData("YessiYes", new int[] { 1, 6 })]
        [InlineData("asdsiYes", new int[] { 6 })]
        [InlineData("No", new int[] { })]
        public void GivenInput_WhenServiceIsCalledWithText_ReturnsPositions(string text, int[] expectedResults)
        {
            var subText = "Yes";
            var result = _service.GetPositionsOfSubString(subText, text);

            Assert.Equal(expectedResults, result);
        }
    }
}