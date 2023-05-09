using System.Collections;

namespace Application.Common.Helpers
{
    public class MathHelper : IEnumerable<object[]>
    {
        public bool IsEven(int number) => number % 2 == 0;

        public int Diff(int x, int y) => y - x;

        public int Add(int x, int y) => x + y;

        public int Sum(params int[] values)
        {
            int sum = 0;
            foreach (var value in values)
                sum += value;

            return sum;
        }

        public double Average(params int[] values)
        {
            int sum = 0;
            foreach (var value in values)
                sum += value;

            return sum / values.Length;
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1, 2, 3 },
                new object[] { -4, -6, -10 },
                new object[] { -2, 2, 0 },
                new object[] { int.MinValue, -1, int.MaxValue },
            };

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { -4, -6, -10 };
            yield return new object[] { -2, 2, 0 };
            yield return new object[] { int.MinValue, -1, int.MaxValue };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
