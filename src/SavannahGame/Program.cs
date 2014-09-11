using System;
using System.Threading;

namespace SavannahGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var game = new Game();

            while (true)
            {
                game.Tick();
                game.Draw();
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
