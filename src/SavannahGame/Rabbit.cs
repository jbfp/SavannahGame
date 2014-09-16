using System;

namespace SavannahGame
{
    public class Rabbit : Animal
    {
        private static readonly Random Random = new Random();

        private readonly IFoodChain mediator;

        public Rabbit(IFoodChain mediator, Gender gender)
            : base(gender, 15.0)
        {
            this.mediator = mediator;
        }

        public override int Moves
        {
            get { return 2; }
        }

        public override double MinWeight
        {
            get { return 2.5; }
        }

        public override void Meet(Grass grass)
        {
            if (grass == null)
            {
                throw new ArgumentNullException("grass");
            }

            if (!grass.IsAlive)
            {
                return;
            }

            GainWeight(1.00);
            grass.Deactivate();
            base.Meet(grass);
        }

        public override void Meet(Animal animal)
        {
            if (animal is Rabbit)
            {
                if (animal.Gender == Gender)
                {
                    return;
                }

                var gender = (Gender)Random.Next(0, 2);
                var bunny = new Rabbit(this.mediator, gender);
                this.mediator.Spawn(bunny);
            }

            base.Meet(animal);
        }
    }
}