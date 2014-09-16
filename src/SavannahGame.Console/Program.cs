using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SavannahGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.CursorVisible = false;

            var game = new Game();

            while (true)
            {
                game.Tick();

                System.Console.SetCursorPosition(0, 0);
                System.Console.ResetColor();

                for (int row = 0; row < Savannah.Size; row++)
                {
                    for (int column = 0; column < Savannah.Size; column++)
                    {
                        System.Console.ResetColor();

                        if (game.Savannah.Grasses[row, column].IsAlive)
                        {
                            System.Console.ForegroundColor = ConsoleColor.Green;
                            System.Console.Write("#");
                        }
                        else
                        {
                            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                            System.Console.Write("·");
                        }
                    }

                    System.Console.WriteLine();
                }

                System.Console.SetCursorPosition(0, 0);
                System.Console.ResetColor();

                for (int row = 0; row < Savannah.Size; row++)
                {
                    for (int column = 0; column < Savannah.Size; column++)
                    {
                        System.Console.ResetColor();

                        Animal animal = game.Savannah.Animals[row, column];

                        if (animal is Lion)
                        {
                            if (animal.Weight < 10.0)
                            {
                                System.Console.ForegroundColor = ConsoleColor.Red;
                            }

                            switch (animal.Gender)
                            {
                                case Gender.Male:
                                    System.Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    break;
                                case Gender.Female:
                                    System.Console.ForegroundColor = ConsoleColor.Cyan;
                                    break;
                            }

                            System.Console.Write("L");
                        }
                        else if (animal is Rabbit)
                        {
                            switch (animal.Gender)
                            {
                                case Gender.Male:
                                    System.Console.ForegroundColor = ConsoleColor.DarkGray;
                                    break;
                                case Gender.Female:
                                    System.Console.ForegroundColor = ConsoleColor.White;
                                    break;
                            }

                            System.Console.Write("R");
                        }
                        else
                        {
                            System.Console.SetCursorPosition(column, row);
                        }
                    }

                    System.Console.WriteLine();
                }

                System.Console.ResetColor();
                System.Console.SetCursorPosition(Savannah.Size + 1, 0);
                System.Console.ForegroundColor = ConsoleColor.White;
                var rabbits = game.Savannah.Animals.OfType<Rabbit>().ToList();
                var rabbitMessage = string.Format("Rabbits: {0} ({1})", rabbits.Count.ToString("D3"), GetFormattedGenderString(rabbits));
                System.Console.Write(new string(' ', System.Console.WindowWidth - 21));
                System.Console.SetCursorPosition(Savannah.Size + 1, 0);
                System.Console.Write(rabbitMessage);
                System.Console.SetCursorPosition(Savannah.Size + 1, 1);
                System.Console.ForegroundColor = ConsoleColor.Cyan;
                var lions = game.Savannah.Animals.OfType<Lion>().ToList();
                System.Console.WriteLine("Lions:   {0} ({1})", lions.Count.ToString("D3"), GetFormattedGenderString(lions));
                System.Console.ResetColor();

                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
        }

        private static string GetFormattedGenderString<T>(IEnumerable<T> animals) where T : Animal
        {
            var males = animals.Count(a => a.Gender == Gender.Male);
            var females = animals.Count(a => a.Gender == Gender.Female);
            var grouped = new[] { males, females };
            return string.Join(" / ", grouped.Select(i => i.ToString("D3")));
        }
    }
}
