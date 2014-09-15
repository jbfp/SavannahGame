using System;

namespace SavannahGame
{
    class RabbitStrategy : IAnimalStrategy
    {
        private static readonly Random Random = new Random();

        private readonly Rabbit rabbit;

        public RabbitStrategy(Rabbit rabbit)
        {
            this.rabbit = rabbit;
        }

        public void Execute(Savannah savannah, int row, int column)
        {
            Grass grass = savannah.GetGrass(row, column);
            Animal other = savannah.GetAnimal(row, column);

            if (grass.IsAlive)
            {
                this.rabbit.Eat(grass);
            }

            if (other is Rabbit && other.Gender != this.rabbit.Gender)
            {
                var gender = (Gender) Random.Next(0, 2);
                var bunny = new Rabbit(gender);
                savannah.Spawn(bunny);
            }
        }
    }
}