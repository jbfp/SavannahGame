using System;

namespace SavannahGame
{
    class Game
    {
        private readonly Random random;
        private readonly Savannah savannah;

        public Game()
        {
            this.random = new Random();
            this.savannah = new Savannah();
        }

        public SavannahState GetCurrentState()
        {
            return savannah.GetCurrenState();
        }

        public void Tick()
        {
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

                    //for (int move = 0; move < 1; move++)
                    {
                        int dx = this.random.Next(-1, 2);
                        int dy = this.random.Next(-1, 2);
                        
                        try
                        {
                            savannah.Move(animal, column, row, dx, dy);
                        }
                        catch (InvalidOperationException)
                        {
                        }
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

                                int x = column + dx;
                                int y = row + dy;

                                if ((x < 0 || x >= Savannah.Size) ||
                                    (y < 0 || y >= Savannah.Size))
                                {
                                    continue;
                                }

                                Animal other = savannah.GetAnimal(y, x);

                                if (other is Lion)
                                {
                                    var gender = (Gender) this.random.Next(0, 2);
                                    var cub = new Lion(gender);
                                    this.savannah.Spawn(cub);                                    
                                }
                                else if (other is Rabbit)
                                {
                                    animal.GainWeight(other.Weight * 0.50);
                                    savannah.Kill((Lion) animal, (Rabbit) other, row + dy, column + dx);
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

                                int x = column + dx;
                                int y = row + dy;

                                if ((x < 0 || x >= Savannah.Size) ||
                                    (y < 0 || y >= Savannah.Size))
                                {
                                    continue;
                                }

                                Grass grass = this.savannah.GetGrass(y, x);
                                Animal other = this.savannah.GetAnimal(y, x);

                                if (grass.IsAlive)
                                {
                                    animal.GainWeight(0.50);
                                    grass.Kill();
                                }

                                if (other is Rabbit)
                                {
                                    var gender = (Gender) this.random.Next(0, 2);
                                    var bunny = new Rabbit(gender);
                                    this.savannah.Spawn(bunny);
                                }
                            }
                        }
                    }

                    animal.LoseWeight(animal.Weight * 0.05);

                    if (animal.Weight < 0.25)
                    {
                        this.savannah.Starve(animal, row, column);
                    }
                }
            }
        }
    }

}