using System;
using System.Linq;
using System.Threading;

namespace SavannahGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var game = new Game();

            while (true)
            {
                game.Tick();
                var state = game.GetCurrentState();

                Console.SetCursorPosition(0, 0);
                Console.ResetColor();

                for (int row = 0; row < Savannah.Size; row++)
                {
                    for (int column = 0; column < Savannah.Size; column++)
                    {
                        Console.ResetColor();

                        if (state.Savannah[row, column].IsAlive)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("#");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("·");
                        }
                    }

                    Console.WriteLine();
                }

                Console.SetCursorPosition(0, 0);
                Console.ResetColor();

                for (int row = 0; row < Savannah.Size; row++)
                {
                    for (int column = 0; column < Savannah.Size; column++)
                    {
                        Console.ResetColor();

                        Animal animal = state.Animals[row, column];

                        if (animal is Lion)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;

                            if (animal.Weight < 10.0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }

                            Console.Write("L");
                        }
                        else if (animal is Rabbit)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("R");
                        }
                        else
                        {
                            Console.SetCursorPosition(column, row);
                        }
                    }

                    Console.WriteLine();
                }

                Console.ResetColor();
                Console.SetCursorPosition(Savannah.Size * 2 + 1, 0);
                Console.WriteLine("Rabbits: {0}", state.Animals.OfType<Rabbit>().Count());
                Console.SetCursorPosition(Savannah.Size * 2 + 1, 1);
                Console.WriteLine("Lions: {0}", state.Animals.OfType<Lion>().Count());

//                Console.Clear();
//                Console.WriteLine(@"     __ __            __   __ 
//  __/ // /_________  / /__/ /_
// /_  _  __/ ___/ _ \/ //_/ __/
///_  _  __/ /  /  __/ ,< / /_  
// /_//_/ /_/   \___/_/|_|\__/ ");

                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
        }
    }
}
