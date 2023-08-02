namespace WebApplication1.Repository
{
    public static class TryParseExtensions
    {
        public static string? TryParseString(this object value)
        {
            if (value == null)
            {
                return null;
            }

            return value.ToString();
        }

        public static DateTime? TryParseDateTime(this object value)
        {
            if (value == null ||
                DateTime.TryParse(value.ToString(), out DateTime result) == false)
            {
                return null;
            }

            return result;
        }
    }
}
