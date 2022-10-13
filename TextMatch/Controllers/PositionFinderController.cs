using Microsoft.AspNetCore.Mvc;

namespace TextMatch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionFinderController : ControllerBase
    {
        private readonly ILogger<PositionFinderController> _logger;
        public const string Text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";

        public PositionFinderController(ILogger<PositionFinderController> logger)
        {
            _logger = logger;
        }



        [HttpGet(Name = "SubTextPositionFinder")]
        public string SubTextPositionFinder(
            [FromQuery] string subtext,
            [FromQuery] string textInput = Text)
        {

            return "";
        }
    }
}