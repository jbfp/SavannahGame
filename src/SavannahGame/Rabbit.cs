namespace SavannahGame
{
    class Rabbit : Animal
    {
        public Rabbit(Gender gender)
            : base(gender)
        {
            GainWeight(2.5);
        }

        public override int Moves
        {
            get { return 2; }
        }
    }
}