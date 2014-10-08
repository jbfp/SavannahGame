using System;
using System.Collections.Generic;
using System.Threading;

namespace SavannahGame.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.CursorVisible = false;

            const int rows = 20;
            const int columns = 20;
            var savannah = new Savannah(rows, columns);
            var game = new Game(savannah);
            var visitor = new ConsoleVisitor();

            while (true)
            {
                IEnumerable<Action> actions = game.Tick();

                foreach (Action action in actions)
                {
                    action();
                }

                System.Console.Clear();
                game.Accept((ISavannahVisitor) visitor);
                game.Accept((IAnimalVisitor) visitor);
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
            }
        }
    }
}