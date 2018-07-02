namespace Application
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ArrayExtensionMethods
    {
        public static T[,] To2D<T>(
            this IEnumerable<IEnumerable<T>> jagged)
        {
            var enumerated = jagged.ToArray();
            var rows = enumerated.Count();
            var columns = enumerated.First().Count();

            var result = new T[rows, columns];

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    result[x, y] = enumerated.ElementAt(x).ElementAt(y);
                }
            }

            return result;
        }
    }
}