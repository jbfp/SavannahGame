using System;

namespace SavannahGame
{
    class Rabbit : Animal
    {
        private static readonly Random Random = new Random();

        private readonly IAnimalMediator mediator;

        public Rabbit(IAnimalMediator mediator, Gender gender)
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

        public void Meet(Grass grass)
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
        }

        public void Meet(Rabbit rabbit)
        {
            if (rabbit == null)
            {
                throw new ArgumentNullException("rabbit");
            }

            if (rabbit.Gender == Gender)
            {
                return;
            }

            var gender = (Gender) Random.Next(0, 2);
            var bunny = new Rabbit(this.mediator, gender);
            this.mediator.Add(bunny);
        }

        public override void Visit(Tile tile)
        {
            if (tile == null)
            {
                throw new ArgumentNullException("tile");
            }

            if (tile.Grass.IsAlive == false)
            {
                return;
            }

            GainWeight(1.00);
            tile.Grass.Deactivate();

            var other = tile.Animal as Rabbit;

            if (other != null)
            {
                if (other.Gender == Gender)
                {
                    return;
                }

                var gender = (Gender) Random.Next(0, 2);
                var bunny = new Rabbit(this.mediator, gender);
                this.mediator.Add(bunny);
            }
        }
    }
}