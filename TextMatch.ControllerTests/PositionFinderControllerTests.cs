using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
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
        [InlineData("Polly", "1,26,51")]
        [InlineData("POLLY", "1,26,51")]
        [InlineData("PoLlY", "1,26,51")]
        [InlineData("polly", "1,26,51")]
        [InlineData("ll", "3,28,53,78,82")]
        [InlineData("Ll", "3,28,53,78,82")]
        [InlineData("LL", "3,28,53,78,82")]
        [InlineData("X", "")]
        [InlineData("x", "")]
        public async Task GivenPollyController_WhenControllerIsCalledWithExistingSubtext_ThenPositionsAreReturned(string subtext, string expectedPositions)
        {
            var result = await _httpClient.GetAsync($"PositionFinder/SubTextPositionFinder?subTextInput={subtext}");
            var response = await result.Content.ReadAsStringAsync();

            result.EnsureSuccessStatusCode();

            Assert.Equal(expectedPositions, response);
        }

        [Fact]
        public async Task GivenPollyController_WhenControllerIsCalledWithSubtext_ThenNullExceptionIsThrown()
        {
            var result = await _httpClient.GetAsync($"PositionFinder/SubTextPositionFinder?subTextInput=");

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}