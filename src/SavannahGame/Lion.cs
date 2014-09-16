using System;

namespace SavannahGame
{
    public class Lion : Animal
    {
        private static readonly Random Random = new Random();
        
        private readonly IFoodChain mediator;

        public Lion(IFoodChain mediator, Gender gender)
            : base(gender, 50.0)
        {
            if (mediator == null)
            {
                throw new ArgumentNullException("mediator");
            }

            this.mediator = mediator;
        }

        public override int Moves
        {
            get { return 1; }
        }

        public override double MinWeight
        {
            get { return 15.0; }
        }

        public void Eat(Rabbit rabbit)
        {
            GainWeight(rabbit.Weight * 0.75);
        }

        public override void Meet(Animal animal)
        {
            if (animal is Lion)
            {
                if (animal.Gender == Gender)
                {
                    return;
                }

                var gender = (Gender)Random.Next(0, 2);
                var cub = new Lion(this.mediator, gender);
                this.mediator.Spawn(cub); 
            }
            else if (animal is Rabbit)
            {
                GainWeight(animal.Weight * 1.0);
                this.mediator.Destroy(animal);    
            }

            base.Meet(animal);
        }
    }
}