using System;
using System.Collections.Generic;
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

            int animalsStarved = 0;
            int rabbitsEaten = 0;
            int grassEaten = 0;

            while (true)
            {
                game.Tick();
                var state = game.GetCurrentState();

                animalsStarved += state.Stats.AnimalsStarved;
                rabbitsEaten += state.Stats.RabbitsEaten;
                grassEaten += state.Stats.GrassEaten;

                Console.SetCursorPosition(0, 0);
                Console.ResetColor();

                for (int row = 0; row < Savannah.Size; row++)
                {
                    for (int column = 0; column < Savannah.Size; column++)
                    {
                        Console.ResetColor();

                        if (state.SavannahState.Savannah[row, column].IsAlive)
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

                        Animal animal = state.SavannahState.Animals[row, column];

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
                Console.SetCursorPosition(Savannah.Size + 1, 0);
                Console.ForegroundColor = ConsoleColor.White;
                var rabbits = state.SavannahState.Animals.OfType<Rabbit>().ToList();
                var rabbitMessage = string.Format("Rabbits: {0} ({1})", rabbits.Count.ToString("D3"), GetFormattedGenderString(rabbits));
                Console.Write(new string(' ', Console.WindowWidth - 21));
                Console.SetCursorPosition(Savannah.Size + 1, 0);
                Console.Write(rabbitMessage);
                Console.SetCursorPosition(Savannah.Size + 1, 1);
                Console.ForegroundColor = ConsoleColor.Cyan;                
                var lions = state.SavannahState.Animals.OfType<Lion>().ToList();
                Console.WriteLine("Lions:   {0} ({1})", lions.Count.ToString("D3"), GetFormattedGenderString(lions));                
                Console.ResetColor();
                Console.SetCursorPosition(Savannah.Size + 1, 3);
                Console.WriteLine("Animals starved: {0} / {1}", state.Stats.AnimalsStarved.ToString("D3"), animalsStarved.ToString("D3"));
                Console.SetCursorPosition(Savannah.Size + 1, 4);
                Console.WriteLine("Rabbits eaten:   {0} / {1}", state.Stats.RabbitsEaten.ToString("D3"), rabbitsEaten.ToString("D3"));
                Console.SetCursorPosition(Savannah.Size + 1, 5);
                Console.WriteLine("Grass eaten:     {0} / {1}", state.Stats.GrassEaten.ToString("D3"), grassEaten.ToString("D3"));

//                Console.Clear();
//                Console.WriteLine(@"     __ __            __   __ 
//  __/ // /_________  / /__/ /_
// /_  _  __/ ___/ _ \/ //_/ __/
///_  _  __/ /  /  __/ ,< / /_  
// /_//_/ /_/   \___/_/|_|\__/ ");

                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
        }

        private static string GetFormattedGenderString<T>(IEnumerable<T> animals) where T : Animal
        {
            var grouped = from animal in animals
                          group animal by animal.Gender
                          into genders
                          select genders.Count().ToString("D3");
            return string.Join(" / ", grouped);
        }
    }
}
