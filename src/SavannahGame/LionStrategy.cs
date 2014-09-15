using System;

namespace SavannahGame
{
    class LionStrategy
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

            var otherLion = other as Lion;

            if (otherLion != null && other.Gender != this.lion.Gender && lion.Weight >= lion.MinWeight && other.Weight >= other.MinWeight)
            {
                this.lion.Meet(otherLion);                
            }
            else
            {
                var rabbit = other as Rabbit;

                if (rabbit != null)
                {
                    this.lion.Eat(rabbit);
                    savannah.Remove(rabbit);
                }
            }
        }

        public void Execute(Lion animal, Savannah savannah, int row, int column)
        {
            throw new NotImplementedException();
        }
    }
}