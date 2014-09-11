using System;

namespace SavannahGame
{
    class Game
    {
        private const int Size = 20;
        private readonly Animal[,] animals;

        private readonly Random random;
        private readonly Grass[,] savannah;

        public Game()
        {
            this.random = new Random();
            this.savannah = new Grass[Size, Size];
            this.animals = new Animal[Size, Size];

            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    this.savannah[row, column] = new Grass(this.random.NextDouble() < 0.10);

                    double x = this.random.NextDouble();
                    var gender = (Gender) this.random.Next(0, 2);

                    if (x < 0.01)
                    {
                        this.animals[row, column] = new Lion(gender);
                    }
                    else if (x < 0.02)
                    {
                        this.animals[row, column] = new Rabbit(gender);
                    }
                }
            }
        }

        public void Tick()
        {
            // Move phase.
            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    Animal animal = this.animals[row, column];

                    if (animal == null)
                    {
                        continue;
                    }

                    int x = column;
                    int y = row;

                    for (int move = 0; move < animal.Moves; move++)
                    {
                        int dx = this.random.Next(-1, 2);
                        int dy = this.random.Next(-1, 2);
                        int newX = Wrap(column + dx, 20);
                        int newY = Wrap(row + dy, 20);

                        if (this.animals[newY, newX] != null)
                        {
                            continue;
                        }

                        this.animals[y, x] = null;
                        this.animals[newY, newX] = animal;

                        x = newX;
                        y = newY;
                    }
                }
            }
            
            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    savannah[row, column].Tick();
                }
            }

            // Action phase.
            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    Animal animal = this.animals[row, column];

                    if (animal == null)
                    {
                        continue;
                    }

                    if (animal is Lion)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            for (int dx = -1; dx <= 1; dx++)
                            {
                                if (dx == 0 && dy == 0)
                                {
                                    continue;
                                }

                                int x = Wrap(column + dx, Size);
                                int y = Wrap(row + dy, Size);

                                Animal other = this.animals[y, x];

                                if (other is Lion)
                                {
                                    var gender = (Gender) this.random.Next(0, 2);
                                    var cub = new Lion(gender);
                                    Spawn(cub);
                                }
                            }
                        }
                    }
                    else if (animal is Rabbit)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            for (int dx = -1; dx <= 1; dx++)
                            {
                                if (dx == 0 && dy == 0)
                                {
                                    continue;
                                }

                                int x = Wrap(column + dx, Size);
                                int y = Wrap(row + dy, Size);

                                Grass grass = this.savannah[y, x];
                                Animal other = this.animals[y, x];

                                if (grass.IsAlive)
                                {
                                    animal.GainWeight(0.50);
                                    grass.Kill();
                                }

                                if (other is Rabbit)
                                {
                                    var gender = (Gender) this.random.Next(0, 2);
                                    var bunny = new Rabbit(gender);
                                    Spawn(bunny);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Spawn<T>(T animal) where T : Animal
        {
            int column = this.random.Next(0, Size);
            int row = this.random.Next(0, Size);

            if (this.animals[row, column] == null)
            {
                this.animals[row, column] = animal;                
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();

            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    Console.ResetColor();

                    if (this.savannah[row, column].IsAlive)
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

            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    Console.ResetColor();

                    Animal animal = this.animals[row, column];

                    if (animal is Lion)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
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
        }

        private int Wrap(int x, int max)
        {
            return ((x % max) + max) % max;
        }
    }
}