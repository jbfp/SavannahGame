using System;

namespace SavannahGame
{
    class Rabbit : Animal
    {
        public Rabbit(Gender gender)
            : base(gender)
        {
            GainWeight(15.0);
        }

        public override int Moves
        {
            get { return 2; }
        }

        public override double MinWeight
        {
            get { return 2.5; }
        }

        public void Eat(Grass grass)
        {
            if (grass == null)
            {
                throw new ArgumentNullException("grass");
            }

            GainWeight(1.00);
            grass.Deactivate();
        }
    }
}