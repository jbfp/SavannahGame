using System;
using System.Collections.Generic;
using System.Linq;

namespace SavannahGame
{
    class Savannah
    {
        public const int Size = 20;

        private readonly Animal[,] animals;
        private readonly Random random;
        private readonly Grass[,] savannah;
        
        public Savannah()
        {
            this.random = new Random();
            this.savannah = new Grass[Size, Size];
            this.animals = new Animal[Size, Size];

            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    this.savannah[row, column] = new Grass(this.random.NextDouble() < 0.50, this.random.Next(5, 15));

                    double x = this.random.NextDouble();
                    var gender = (Gender) this.random.Next(0, 2);

                    if (x < 0.05)
                    {
                        this.animals[row, column] = new Lion(gender);
                    }
                    else if (x < 0.10)
                    {
                        this.animals[row, column] = new Rabbit(gender);
                    }
                }
            }
        }

        public IReadOnlyCollection<Animal> Animals
        {
            get { return this.animals.OfType<Animal>().ToList().AsReadOnly(); }
        }

        public void Spawn(Animal animal)
        {
            int column = this.random.Next(0, Size);
            int row = this.random.Next(0, Size);

            if (this.animals[row, column] == null)
            {
                this.animals[row, column] = animal;
            }

            this.animals[row, column] = animal;
        }

        public Grass GetGrass(int row, int column)
        {
            return this.savannah[row, column];
        }

        public Animal GetAnimal(int row, int column)
        {
            return this.animals[row, column];
        }

        public void Move(Animal animal, int x, int y, int dx, int dy)
        {
            int newX = x + dx;
            int newY = y + dy;

            if ((newX < 0 || newX >= Size) ||
                (newY < 0 || newY >= Size))
            {
                return;
            }

            if (GetAnimal(newY, newX) != null)
            {
                return;
            }

            this.animals[y, x] = null;
            this.animals[newY, newX] = animal;
        }

        public void Kill(Lion predator, Rabbit victim, int row, int column)
        {
            if (predator == null)
            {
                throw new ArgumentNullException("predator");
            }

            if (victim == null)
            {
                throw new ArgumentNullException("victim");
            }

            if ((row < 0 || row >= Size) ||
                (column < 0 || column >= Size))
            {
                throw new ArgumentOutOfRangeException();
            }

            this.animals[row, column] = null;
        }

        public void Starve(Animal animal, int row, int column)
        {
            if (animal == null)
            {
                throw new ArgumentNullException("animal");
            }

            if (this.animals[row, column] == null)
            {
                string message = string.Format("No animal found at ({0}, {1}).", column.ToString(), row.ToString());
                throw new InvalidOperationException(message);
            }

            if ((row < 0 || row >= Size) ||
                (column < 0 || column >= Size))
            {
                throw new ArgumentOutOfRangeException();
            }

            this.animals[row, column] = null;
        }


        public SavannahState GetCurrenState()
        {
            return new SavannahState(this.savannah, this.animals);
        }
    }
}