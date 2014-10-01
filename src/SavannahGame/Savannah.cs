using System;
using System.Collections.Generic;
using System.Linq;

namespace SavannahGame
{
    public class Savannah : IAnimalSpawner
    {
        private static readonly Random Random = new Random();

        private readonly int rows;
        private readonly int columns;
        private readonly Grass[,] savannah;
        private readonly Animal[,] animals;

        public Savannah(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.savannah = new Grass[this.rows, this.columns];
            this.animals = new Animal[this.rows, this.columns];

            for (int row = 0; row < this.rows; row++)
            {
                for (int column = 0; column < this.columns; column++)
                {
                    this.savannah[row, column] = new Grass(Random.Next(1, 15), Random.NextDouble() < 0.50, column, row);
                }
            }

            for (int i = 0; i < NumTiles; i++)
            {
                double x = Random.NextDouble();
                var gender = (Gender) Random.Next(0, 2);
                
                if (x < 0.05)
                {
                    Spawn(new Lion(this, gender));
                }
                else if (x < 0.20)
                {
                    Spawn(new Rabbit(this, gender));
                }
            }
        }
        
        public int NumTiles
        {
            get { return this.rows * this.columns; }
        }

        public IReadOnlyCollection<Grass> Grasses
        {
            get { return this.savannah.OfType<Grass>().ToList().AsReadOnly(); }
        }

        public IReadOnlyCollection<Animal> Animals
        {
            get { return this.animals.OfType<Animal>().ToList().AsReadOnly(); }
        }

        public void Spawn<T>(T animal) where T : Animal
        {
            int row = Random.Next(0, this.rows);
            int column = Random.Next(0, this.columns);            

            if (this.animals[row, column] == null)
            {
                this.animals[row, column] = animal;
                animal.Y = row;
                animal.X = column;                
            }
        }

        public void Move(Animal animal, int row, int column)
        {
            if (column < 0 || column >= this.columns || row < 0 || row >= this.rows)
            {
                return;
            }

            if (Animals.Any(a => a.X == column && a.Y == row))
            {
                return;
            }

            this.animals[animal.Y, animal.X] = null;
            this.animals[row, column] = animal;
            animal.X = column;
            animal.Y = row;
        }

        public void Remove(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException("animal");
            }

            this.animals[animal.Y, animal.X] = null;
        }
    }
}