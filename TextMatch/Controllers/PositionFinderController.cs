using Microsoft.AspNetCore.Mvc;
using TextMatch.Extensions;
using TextMatch.Services;

namespace TextMatch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionFinderController : ControllerBase
    {
        private readonly ILogger<PositionFinderController> _logger;
        private readonly ISubstringPositionsFinderService _substringPositionsFinder;

        public PositionFinderController(ILogger<PositionFinderController> logger, ISubstringPositionsFinderService substringPositionsFinder)
        {
            _logger = logger;
            _substringPositionsFinder = substringPositionsFinder;
        }

        [HttpGet]
        [Route("SubTextPositionFinder")]
        public IActionResult SubTextPositionFinder(
            string subTextInput,
            string? textInput)
        {
            _logger.LogInformation($"Received request with params {nameof(textInput)}: {textInput}, {nameof(subTextInput)}: {subTextInput}");

            if (subTextInput == null || subTextInput.Length < 1)
            {
                _logger.LogError($"{nameof(subTextInput)} was null");
                throw new ArgumentNullException("You must give a subtext input!");
            }

            IList<int>? positionsFound = _substringPositionsFinder.GetPositionsOfSubString(subTextInput, textInput);

            return Ok(positionsFound.ToPositionalString());
        }
    }
}