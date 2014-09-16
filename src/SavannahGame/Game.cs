using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavannahGame
{
    public class Game
    {
        private static readonly Random Random = new Random();

        private readonly Savannah savannah;
        private readonly List<Animal> updatedAnimals;

        public Game()
        {
            this.savannah = new Savannah();
            this.updatedAnimals = new List<Animal>(this.savannah.Rows * this.savannah.Columns);
        }

        public Savannah Savannah
        {
            get { return this.savannah; }
        }

        public void Tick()
        {
            this.updatedAnimals.Clear();
            Move();
            Act();
        }

        public IEnumerable<Task> TickAsync()
        {
            this.updatedAnimals.Clear();

            foreach (var task in MoveAsync())
            {
                yield return task;
            }

            foreach (var task in ActAsync())
            {
                yield return task;
            }

            foreach (var task in CleanupAsync())
            {
                yield return task;
            }
        }

        private IEnumerable<Task> MoveAsync()
        {
            for (int row = 0; row < this.savannah.Rows; row++)
            {
                for (int column = 0; column < this.savannah.Columns; column++)
                {
                    Animal animal = this.savannah.Animals[row, column];

                    if (animal == null)
                    {
                        continue;
                    }

                    for (int move = 0; move < animal.Moves; move++)
                    {
                        int dx = Random.Next(-1, 2);
                        int dy = Random.Next(-1, 2);

                        if (dx == 0 && dy == 0)
                        {
                            continue;
                        }

                        yield return Task.Run(() => this.savannah.Move(animal, dy, dx));
                    }
                }
            }
        }

        private IEnumerable<Task> ActAsync()
        {
            for (int row = 0; row < this.savannah.Rows; row++)
            {
                for (int column = 0; column < this.savannah.Columns; column++)
                {
                    // Update grass.
                    var grass = this.savannah.Grasses[row, column];
                    yield return Task.Run(() => grass.Tick());

                    Animal animal = this.savannah.Animals[row, column];

                    if (animal == null)
                    {
                        continue;
                    }

                    if (animal.IsAlive == false)
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
                    int animals = this.savannah.Animals.OfType<Animal>().Count(a => a.GetType() == animal.GetType());
                    double k = Random.NextDouble();
                    bool dies = animal.Weight < animal.MinWeight || k < ((1.0 * animals) / (1.0 * max)) || animal.Age > Random.Next(5, 20);

                    if (dies)
                    {
                        yield return Task.Run(() => this.savannah.Destroy(animal));
                        continue;
                    }

                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            int x = column + dx;
                            int y = row + dy;

                            if ((x < 0 || x >= this.savannah.Columns) ||
                                (y < 0 || y >= this.savannah.Rows))
                            {
                                continue;
                            }

                            Grass neighbourGrass = this.savannah.Grasses[y, x];
                            Animal neighbourAnimal = this.savannah.Animals[y, x];

                            var grassTask = Task.Run(() => animal.Meet(neighbourGrass));
                            var animalTask = Task.Run(() => animal.Meet(neighbourAnimal));
                            yield return Task.WhenAll(grassTask, animalTask);
                        }
                    }

                    this.updatedAnimals.Add(animal);
                }
            }
        }

        private IEnumerable<Task> CleanupAsync()
        {
            for (int row = 0; row < this.savannah.Rows; row++)
            {
                for (int column = 0; column < this.savannah.Columns; column++)
                {
                    var animal = this.savannah.Animals[row, column];

                    if (animal == null)
                    {
                        continue;
                    }

                    if (animal.IsAlive == false)
                    {
                        yield return Task.Run(() => this.savannah.Remove(animal));
                    }
                }
            }
        }

        private void Act()
        {
            for (int row = 0; row < this.savannah.Rows; row++)
            {
                for (int column = 0; column < this.savannah.Columns; column++)
                {
                    // Update grass.
                    this.savannah.Grasses[row, column].Tick();

                    Animal animal = this.savannah.Animals[row, column];

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
                    int animals = this.savannah.Animals.OfType<Animal>().Count(a => a.GetType() == animal.GetType());
                    double k = Random.NextDouble();
                    bool dies = animal.Weight < animal.MinWeight || k < ((1.0 * animals) / (1.0 * max)) || animal.Age > Random.Next(5, 20);

                    if (dies)
                    {
                        this.savannah.Destroy(animal);
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

                            Grass grass = this.savannah.Grasses[y, x];
                            Animal other = this.savannah.Animals[y, x];

                            animal.Meet(grass);
                            animal.Meet(other);
                        }
                    }

                    this.updatedAnimals.Add(animal);
                }
            }
        }

        private void Move()
        {
            for (int row = 0; row < this.savannah.Rows; row++)
            {
                for (int column = 0; column < this.savannah.Columns; column++)
                {
                    Animal animal = this.savannah.Animals[row, column];

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
        }
    }
}