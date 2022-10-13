using Microsoft.AspNetCore.Mvc.Testing;
using TextMatch.ControllerTests.Setup;

namespace TextMatch.ControllerTests
{
    public class PositionFinderControllerTests
        : IClassFixture<TextMatchWebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public PositionFinderControllerTests(TextMatchWebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

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
        public void GivenPollyController_WhenControllerIsCalledWithExistingSubtext_ThenPositionsAreReturned(string subtext, string expectedPositions)
        {
            //_httpClient
        }

        [Fact]
        public void GivenPollyController_WhenControllerIsCalledWithSubtext_ThenNullExceptionIsThrown()
        {

        }
    }
}