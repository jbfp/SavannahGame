using System;

namespace SavannahGame
{
    public class Rabbit : Animal
    {
        private static readonly Random Random = new Random();

        private readonly IAnimalSpawner spawner;

        public Rabbit(IAnimalSpawner spawner, Gender gender)
            : base(gender, 7.5)
        {
            this.spawner = spawner;
        }

        public override int Moves
        {
            get { return 2; }
        }

        protected override double MinWeight
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
                var bunny = new Rabbit(this.spawner, gender);
                this.spawner.Spawn(bunny);
            }

            base.Visit(rabbit);
        }

        public override void Accept(IAnimalVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}