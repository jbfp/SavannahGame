using System;
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


                Console.SetCursorPosition(0, 0);
                Console.ResetColor();

                for (int row = 0; row < Savannah.Size; row++)
                {
                    for (int column = 0; column < Savannah.Size; column++)
                    {
                        Console.ResetColor();

                        if (game.Savannah.GetGrass(row, column)
                                .IsAlive)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("#");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(".");
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

                        Animal animal = game.Savannah.GetAnimal(row, column);

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
                            Console.WriteLine("R");
                        }
                        else
                        {
                            Console.SetCursorPosition(column, row);
                        }
                    }

                    Console.WriteLine();
                }

                Console.ResetColor();
                Console.SetCursorPosition(Savannah.Size + 1, 0);
                Console.WriteLine("Rabbits: {0}", game.Savannah.Rabbits.Count);
                Console.SetCursorPosition(Savannah.Size + 1, 1);
                Console.WriteLine("Lions: {0}", game.Savannah.Lions.Count);

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
