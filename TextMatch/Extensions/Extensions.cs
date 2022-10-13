namespace TextMatch.Extensions
{
    public static class Extensions
    {
        public static char[] ToLowerChars(this string Input)
        {
            return Input.ToLower().ToCharArray();
        }

        public static string ToPositionalString(this IEnumerable<int> Input)
        {
            return string.Join(",", Input);
        }
    }
}
