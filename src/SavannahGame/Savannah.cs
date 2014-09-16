using System;

namespace SavannahGame
{
    public class Savannah : IFoodChain
    {
        public const int Size = 20;

        private readonly Animal[,] animals;
        private readonly Random random;
        private readonly Grass[,] savannah;

        public Savannah()
        {
            this.random = new Random();
            this.savannah = new Grass[Rows, Columns];
            this.animals = new Animal[Rows, Columns];

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    this.savannah[row, column] = new Grass(this.random.NextDouble() < 0.50, this.random.Next(5, 15));

                    double x = this.random.NextDouble();
                    var gender = (Gender) this.random.Next(0, 2);

                    if (x < 0.05)
                    {
                        this.animals[row, column] = new Lion(this, gender);
                    }
                    else if (x < 0.20)
                    {
                        this.animals[row, column] = new Rabbit(this, gender);
                    }
                }
            }
        }

        public int Rows
        {
            get { return Size; }
        }

        public int Columns
        {
            get { return Size; }
        }

        public Animal[,] Animals
        {
            get { return this.animals; }
        }

        public Grass[,] Grasses
        {
            get { return this.savannah; }
        }

        public void Spawn<T>(T animal) where T : Animal
        {
            int column = this.random.Next(0, Size);
            int row = this.random.Next(0, Size);

            if (this.animals[row, column] == null)
            {
                this.animals[row, column] = animal;
            }
        }

        public void Destroy<T>(T animal) where T : Animal
        {
            if (animal == null)
            {
                throw new ArgumentNullException("animal");
            }

            animal.Deactivate();

            //for (int row = 0; row < Size; row++)
            //{
            //    for (int column = 0; column < Size; column++)
            //    {
            //        if (this.animals[row, column] == animal)
            //        {
            //            this.animals[row, column] = null;
            //        }
            //    }
            //}
        }

        public void Move(Animal animal, int dr, int dc)
        {
            if (dr == 0 && dc == 0)
            {
                return;
            }

            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    if (this.animals[row, column] == animal)
                    {
                        int newRow = row + dr;
                        int newColumn = column + dc;

                        if ((newRow < 0 || newRow >= Size) || (newColumn < 0 || newColumn >= Size))
                        {
                            return;
                        }

                        if (this.animals[newRow, newColumn] != null)
                        {
                            return;
                        }

                        this.animals[row, column] = null;
                        this.animals[newRow, newColumn] = animal;
                        return;
                    }
                }
            }
        }

        public void Remove(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException("animal");
            }

            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    if (this.animals[row, column] == animal)
                    {
                        this.animals[row, column] = null;
                    }
                }
            }
        }
    }
}