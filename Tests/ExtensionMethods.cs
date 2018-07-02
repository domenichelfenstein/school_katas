namespace Tests
{
    using System.Linq;
    using Application;

    public static class ExtensionMethods
    {
        public static Grid ToGrid(
            this string input)
        {
            var parts = input
                .Split('x')
                .Select(int.Parse)
                .ToArray();
            return new Grid(
                parts[0],
                parts[1]);
        }

        public static (int X, int Y) ToPosition(
            this string input)
        {
            var parts = input
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            return (
                parts[0],
                parts[1]);
        }
    }
}