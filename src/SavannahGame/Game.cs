using System;
using System.Collections.Generic;
using System.Linq;

namespace SavannahGame
{
    class Game
    {
        private readonly AnimalStrategyFactory animalStrategyFactory;
        private readonly Random random;
        private readonly Savannah savannah;
        private readonly List<Animal> updatedAnimals; 

        private int animalsStarvedTick;
        private int rabbitsEatenTick;
        private int grassEatenTick;

        public Game(AnimalStrategyFactory animalStrategyFactory)
        {
            this.animalStrategyFactory = animalStrategyFactory;
            this.random = new Random();
            this.savannah = new Savannah();
            this.updatedAnimals = new List<Animal>(Savannah.Size * Savannah.Size);
        }

        public GameState GetCurrentState()
        {
            var savannahState = savannah.GetCurrenState();
            var stats = new Stats(this.animalsStarvedTick, this.rabbitsEatenTick, this.grassEatenTick);
            return new GameState(savannahState, stats);
        }

        public void Tick()
        {
            this.updatedAnimals.Clear();

            // Move phase.
            for (int row = 0; row < Savannah.Size; row++)
            {
                for (int column = 0; column < Savannah.Size; column++)
                {
                    Animal animal = this.savannah.GetAnimal(row, column);

                    if (animal == null)
                    {
                        continue;
                    }

                    for (int move = 0; move < animal.Moves; move++)
                    {
                        int dx = this.random.Next(-1, 2);
                        int dy = this.random.Next(-1, 2);
                        savannah.Move(animal, column, row, dx, dy);
                    }
                }
            }

            // Action phase.
            for (int row = 0; row < Savannah.Size; row++)
            {
                for (int column = 0; column < Savannah.Size; column++)
                {
                    // Update grass.
                    this.savannah.GetGrass(row, column).Tick();

                    Animal animal = this.savannah.GetAnimal(row, column);

                    if (animal == null)
                    {
                        continue;
                    }

                    if (this.updatedAnimals.Contains(animal))
                    {
                        continue;
                    }

                    animal.GetOlder();
                    animal.LoseWeight(animal.Weight * 0.10);

                    // Dies from overpopulation or starvation?
                    const int max = Savannah.Size * Savannah.Size;
                    var animals = this.savannah.Animals.Count(a => a.GetType() == animal.GetType());
                    var k = this.random.NextDouble();
                    var dies = animal.Weight < animal.MinWeight || k < (2.0 * animals / max) || animal.Age > this.random.Next(5, 20);

                    if (dies)
                    {
                        this.savannah.Starve(animal, row, column);
                        continue;
                    }

                    var strategy = animalStrategyFactory.GetStrategy(animal);

                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            int x = column + dx;
                            int y = row + dy;

                            if ((x < 0 || x >= Savannah.Size) ||
                                (y < 0 || y >= Savannah.Size))
                            {
                                continue;
                            }

                            strategy.Execute(savannah, y, x);
                        }
                    }

                    this.updatedAnimals.Add(animal);
                }
            }
        }
    }
}