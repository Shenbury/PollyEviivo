using TextMatch.Constants;

namespace TextMatch.Services
{
    public interface ISubstringPositionsFinderService
    {
        IList<int> GetPositionsOfSubString(string subTextInput, string textInput);
    }
}
