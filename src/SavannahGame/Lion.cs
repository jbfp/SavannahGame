namespace SavannahGame
{
    class Lion : Animal
    {
        public Lion(Gender gender)
            : base(gender)
        {
            GainWeight(50.0);
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
    }
}