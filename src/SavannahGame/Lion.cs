using System;

namespace SavannahGame
{
    public class Lion : Animal
    {
        private static readonly Random Random = new Random();
        
        private readonly IAnimalSpawner spawner;

        public Lion(IAnimalSpawner spawner, Gender gender)
            : base(gender, 25.0)
        {
            if (spawner == null)
            {
                throw new ArgumentNullException("spawner");
            }

            this.spawner = spawner;
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
                var cub = new Lion(this.spawner, gender);
                this.spawner.Spawn(cub);
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