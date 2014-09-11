namespace SavannahGame
{
    abstract class Animal
    {
        private readonly Gender gender;
        private double weight;

        protected Animal(Gender gender)
        {
            this.gender = gender;
            this.weight = 1.0;
        }

        public Gender Gender
        {
            get { return gender; }
        }

        public double Weight
        {
            get { return weight; }
        }

        public abstract int Moves { get; }

        public void GainWeight(double weightGained)
        {
            weight += weightGained;
        }

        public void LoseWeight(double weightLost)
        {
            weight -= weightLost;
        }
    }
}