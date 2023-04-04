namespace Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsContainsChar(this string text,int minCount)
        {
          var results= text.Select(x => char.IsLetter(x));

          if (results.Count(x=>x == true) == minCount)
          {
              return true;
          }

          return false;
        }
    }
}
