using TextMatch.Constants;
using TextMatch.Extensions;

namespace TextMatch.Services
{
    public class SubstringPositionsFinderService : ISubstringPositionsFinderService
    {
        private readonly ILogger _logger;

        public SubstringPositionsFinderService(ILogger<SubstringPositionsFinderService> logger)
        {
            _logger = logger;
        }


        public IList<int> GetPositionsOfSubString(string subTextInput, string textInput)
        {
            if (textInput == null || textInput.Length < 1)
            {
                textInput = TextConstants.ExampleText;
            }

            _logger.LogInformation($"Calculating Positions for {nameof(textInput)}: {textInput}, {nameof(subTextInput)}: {subTextInput}");

            int positionOffset = 2;
            int currentMatchingLength = 0;
            int subTextIndex = 0;

            char[] charactersFromText = textInput.ToLowerChars();
            char[] charactersFromSubText = subTextInput.ToLowerChars();

            List<int> positionsFound = new List<int>();

            for (int textIndex = 0; textIndex < charactersFromText.Length; textIndex++)
            {
                var currentTextChar = charactersFromText[textIndex];
                var currentSubTextChar = charactersFromSubText[subTextIndex];

                if (currentSubTextChar == currentTextChar)
                {
                    _logger.LogInformation($"Found matching chars {nameof(currentSubTextChar)}: {currentSubTextChar}, {nameof(currentTextChar)}: {currentTextChar}");

                    currentMatchingLength++;
                    if (currentMatchingLength == charactersFromSubText.Length)
                    {
                        int position = textIndex - (charactersFromSubText.Length - positionOffset);

                        _logger.LogInformation($"Position found at {nameof(position)}: {position} for {nameof(subTextInput)}: {subTextInput}");

                        positionsFound.Add(position);
                        subTextIndex = 0;
                    }
                    else
                    {
                        subTextIndex++;
                    }
                }
                else
                {
                    currentMatchingLength = 0;
                    subTextIndex = 0;
                }
            }
            _logger.LogInformation($"Completed finding positions for {nameof(subTextInput)}: {subTextInput} and {nameof(textInput)}: {textInput}");

            return positionsFound;
        }
    }
}
