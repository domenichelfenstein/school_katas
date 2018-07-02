namespace Application
{
    using System;
    using System.Threading;

    public static class Program
    {
        public static void Main(string[] _)
        {
            var input =
@"
...................
......oo......o...o
.....oooo......ooo.
oo....ooooo...oo..o
ooo...oo..o...oooo.
...................";

            var gameOfLife = new GameOfLife();
            while (true)
            {
                Console.Clear();
                Console.Write(input);
                input = gameOfLife.NextStep(input);
                Thread.Sleep(500);
            }
        }
    }
}
