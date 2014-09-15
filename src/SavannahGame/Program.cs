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

            var game = new Game(new AnimalStrategyFactory());

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
                            Console.Write("# ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("· ");
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
                            if (animal.Weight < 10.0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }

                            switch (animal.Gender)
                            {
                                case Gender.Male:
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    break;
                                case Gender.Female:
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    break;
                            }

                            Console.Write("L ");
                        }
                        else if (animal is Rabbit)
                        {
                            switch (animal.Gender)
                            {
                                case Gender.Male:
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    break;
                                case Gender.Female:
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                            }

                            Console.Write("R ");
                        }
                        else
                        {
                            Console.SetCursorPosition(column + 1, row);
                        }
                    }

                    Console.WriteLine();
                }

                //Console.ResetColor();
                //Console.SetCursorPosition(Savannah.Size + 1, 0);
                //Console.ForegroundColor = ConsoleColor.White;
                //var rabbits = state.SavannahState.Animals.OfType<Rabbit>().ToList();
                //var rabbitMessage = string.Format("Rabbits: {0} ({1})", rabbits.Count.ToString("D3"), GetFormattedGenderString(rabbits));
                //Console.Write(new string(' ', Console.WindowWidth - 21));
                //Console.SetCursorPosition(Savannah.Size + 1, 0);
                //Console.Write(rabbitMessage);
                //Console.SetCursorPosition(Savannah.Size + 1, 1);
                //Console.ForegroundColor = ConsoleColor.Cyan;                
                //var lions = state.SavannahState.Animals.OfType<Lion>().ToList();
                //Console.WriteLine("Lions:   {0} ({1})", lions.Count.ToString("D3"), GetFormattedGenderString(lions));                
                //Console.ResetColor();
                //Console.SetCursorPosition(Savannah.Size + 1, 3);
                //Console.WriteLine("Animals starved: {0} / {1}", state.Stats.AnimalsStarved.ToString("D3"), animalsStarved.ToString("D3"));
                //Console.SetCursorPosition(Savannah.Size + 1, 4);
                //Console.WriteLine("Rabbits eaten:   {0} / {1}", state.Stats.RabbitsEaten.ToString("D3"), rabbitsEaten.ToString("D3"));
                //Console.SetCursorPosition(Savannah.Size + 1, 5);
                //Console.WriteLine("Grass eaten:     {0} / {1}", state.Stats.GrassEaten.ToString("D3"), grassEaten.ToString("D3"));

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
