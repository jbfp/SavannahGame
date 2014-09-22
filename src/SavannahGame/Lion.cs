using System;

namespace SavannahGame
{
    public class Lion : Animal
    {
        private static readonly Random Random = new Random();
        
        private readonly IAnimalSpawner mediator;

        public Lion(IAnimalSpawner mediator, Gender gender)
            : base(gender, 25.0)
        {
            if (mediator == null)
            {
                throw new ArgumentNullException("mediator");
            }

            this.mediator = mediator;
        }

        protected override double MinWeight
        {
            get { return 15.0; }
        }

        public override int Moves
        {
            get { return 1; }
        }        

        public override void Visit(Lion lion)
        {
            if (lion.Gender == Gender)
            {
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                var gender = (Gender) Random.Next(0, 2);
                var cub = new Lion(this.mediator, gender);
                this.mediator.Spawn(cub);
            }

            base.Visit(lion);
        }

        public override void Visit(Rabbit rabbit)
        {
            if (rabbit.IsAlive == false)
            {
                return;
            }

            GainWeight(rabbit.Weight * 1.0);
            rabbit.Deactivate();
            base.Visit(rabbit);
        }

        public override void Accept(IAnimalVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}