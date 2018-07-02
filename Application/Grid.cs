namespace Application
{
    public class Grid
    {
        public Grid(
            int width,
            int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; }

        public int Height { get; }
    }
}