using System;

namespace SavannahGame
{
    public class Rabbit : Animal
    {
        private static readonly Random Random = new Random();

        private readonly IAnimalSpawner mediator;

        public Rabbit(IAnimalSpawner mediator, Gender gender)
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

        public override void Visit(Grass grass)
        {
            if (grass == null)
            {
                throw new ArgumentNullException("grass");
            }

            if (grass.IsAlive == false)
            {
                return;
            }

            GainWeight(1.00);
            grass.Deactivate();
            base.Visit(grass);
        }

        public override void Visit(Rabbit rabbit)
        {
            if (rabbit.Gender == Gender)
            {
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                var gender = (Gender)Random.Next(0, 2);
                var bunny = new Rabbit(this.mediator, gender);
                this.mediator.Spawn(bunny);
            }

            base.Visit(rabbit);
        }

        public override void Accept(IAnimalVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}