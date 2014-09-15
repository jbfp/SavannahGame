using System;
using System.Collections.Generic;
using System.Linq;

namespace SavannahGame
{
    class Game
    {
        private static readonly Random Random = new Random();

        private readonly Savannah savannah;
        private readonly List<Animal> updatedAnimals;

        public Game()
        {
            this.savannah = new Savannah();
            this.updatedAnimals = new List<Animal>(this.savannah.Rows * this.savannah.Columns);
        }

        public SavannahState GetSavannahState()
        {
            return this.savannah.GetCurrenState();
        }

        public void Tick()
        {
            this.updatedAnimals.Clear();

            // Move phase.
            for (int row = 0; row < this.savannah.Rows; row++)
            {
                for (int column = 0; column < this.savannah.Columns; column++)
                {
                    Animal animal = this.savannah.GetAnimal(row, column);

                    if (animal == null)
                    {
                        continue;
                    }

                    for (int move = 0; move < animal.Moves; move++)
                    {
                        int dx = Random.Next(-1, 2);
                        int dy = Random.Next(-1, 2);
                        this.savannah.Move(animal, dy, dx);
                    }
                }
            }

            // Action phase.
            for (int row = 0; row < this.savannah.Rows; row++)
            {
                for (int column = 0; column < this.savannah.Columns; column++)
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
                    int max = this.savannah.Rows * this.savannah.Columns;
                    int animals = this.savannah.Animals.Count(a => a.GetType() == animal.GetType());
                    double k = Random.NextDouble();
                    bool dies = animal.Weight < animal.MinWeight || k < (1.0 * animals / max) || animal.Age > Random.Next(5, 20);

                    if (dies)
                    {
                        this.savannah.Remove(animal);
                        continue;
                    }

                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            if (dy == 0 && dx == 0)
                            {
                                continue;
                            }

                            int x = column + dx;
                            int y = row + dy;

                            if ((x < 0 || x >= this.savannah.Columns) ||
                                (y < 0 || y >= this.savannah.Rows))
                            {
                                continue;
                            }

                            Grass grass = this.savannah.GetGrass(y, x);
                            Animal other = this.savannah.GetAnimal(y, x);
                            var tile = new Tile(grass, other);

                            animal.Visit(tile);
                        }
                    }

                    this.updatedAnimals.Add(animal);
                }
            }

            // Cleanup phase.
            for (int row = 0; row < this.savannah.Rows; row++)
            {
                for (int column = 0; column < this.savannah.Columns; column++)
                {
                    Animal animal = this.savannah.GetAnimal(row, column);

                    if (animal == null)
                    {
                        continue;
                    }

                    if (animal.IsAlive == false)
                    {
                        this.savannah.Remove(animal);
                    }
                }
            }
        }
    }

    class Tile
    {
        private readonly Grass grass;
        private readonly Animal animal;

        public Tile(Grass grass, Animal animal)
        {
            this.grass = grass;
            this.animal = animal;
        }

        public Grass Grass
        {
            get { return this.grass; }
        }

        public Animal Animal
        {
            get { return this.animal; }
        }
    }
}