namespace TextMatch.UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Polly", "1, 26, 51")]
        [InlineData("POLLY", "1, 26, 51")]
        [InlineData("PoLlY", "1, 26, 51")]
        [InlineData("polly", "1, 26, 51")]
        [InlineData("ll", "3, 28, 53, 78, 82")]
        [InlineData("Ll", "3, 28, 53, 78, 82")]
        [InlineData("LL", "3, 28, 53, 78, 82")]
        [InlineData("X", "")]
        [InlineData("x", "")]
        public void GivenInput_WhenServiceIsCalled_ReturnsPositions(string subtext, string expectedResult)
        {

        }

        [Fact]
        public void GivenPolx_WhenServiceIsCalled_ThrowsNullException()
        {
            string text = "Polx";


        }
    }
}