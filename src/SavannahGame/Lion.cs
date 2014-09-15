using System;

namespace SavannahGame
{
    class Lion : Animal
    {
        private static readonly Random Random = new Random();
        
        private readonly IAnimalMediator mediator;

        public Lion(IAnimalMediator mediator, Gender gender)
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

        public override void Visit(Tile tile)
        {
        }

        public void Eat(Rabbit rabbit)
        {
            GainWeight(rabbit.Weight * 0.75);
        }

        public void Meet(Lion lion)
        {
            if (lion == null)
            {
                throw new ArgumentNullException("lion");
            }

            if (lion.Gender == Gender)
            {
                return;
            }

            var gender = (Gender) Random.Next(0, 2);
            var cub = new Lion(this.mediator, gender);
            this.mediator.Add(cub);
        }

        public void Meet(Rabbit rabbit)
        {
            if (rabbit == null)
            {
                throw new ArgumentNullException("rabbit");
            }

            GainWeight(rabbit.Weight * 1.0);
            this.mediator.Remove(rabbit);
        }
    }
}