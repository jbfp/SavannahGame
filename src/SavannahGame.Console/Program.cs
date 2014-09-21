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

            var savannah = new Savannah(20, 20);
            var game = new Game(savannah);
            var visitor = new ConsoleVisitor();

            while (true)
            {
                IEnumerable<Action> actions = game.Tick();

                foreach (Action action in actions)
                {
                    action();
                    game.Accept((ISavannahVisitor) visitor);
                    game.Accept((IAnimalVisitor) visitor);
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
            }
        }
    }
}