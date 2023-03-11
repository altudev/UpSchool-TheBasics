namespace UpSchool.Domain.Utilities
{
    public static class StringHelper
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);

            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
