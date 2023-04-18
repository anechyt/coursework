namespace Coursework.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceSpaceAndComma(this string value)
        {
            if (value.Contains(","))
                return value.Replace(",", "%2C");

            if (value.Contains(" "))
                return value.Replace(" ", "%20");

            return value;
        }
    }
}
