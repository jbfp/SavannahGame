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
    }
}