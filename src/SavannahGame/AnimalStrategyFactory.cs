using System;

namespace SavannahGame
{
    class AnimalStrategyFactory
    {
        public IAnimalStrategy GetStrategy(Animal animal)
        {
            var lion = animal as Lion;

            if (lion != null)
            {
                return new LionStrategy(lion);
            }

            var rabbit = animal as Rabbit;
            
            if (rabbit != null)
            {
                return new RabbitStrategy(rabbit);
            }
            
            throw new ArgumentOutOfRangeException();
        }
    }
}