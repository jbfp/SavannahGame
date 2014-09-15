using System;

namespace SavannahGame
{
    class LionStrategy : IAnimalStrategy
    {
        private static readonly Random Random = new Random();

        private readonly Lion lion;

        public LionStrategy(Lion lion)
        {
            this.lion = lion;
        }

        public void Execute(Savannah savannah, int row, int column)
        {
            Animal other = savannah.GetAnimal(row, column);

            if (other == null)
            {
                return;
            }

            if (other is Lion && other.Gender != this.lion.Gender && lion.Weight >= lion.MinWeight && other.Weight >= other.MinWeight)
            {
                var gender = (Gender) Random.Next(0, 2);
                var cub = new Lion(gender);
                savannah.Spawn(cub);
            }
            else if (other is Rabbit)
            {
                this.lion.GainWeight(other.Weight * 0.50);
                savannah.Kill(this.lion, (Rabbit) other, row, column);
            }
        }
    }
}