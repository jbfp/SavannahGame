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
    }
}