namespace SavannahGame
{
    public abstract class Animal
    {
        private readonly Gender gender;

        protected Animal(Gender gender, double weight)
        {
            this.gender = gender;
            IsAlive = true;
            GainWeight(weight);
        }

        public Gender Gender
        {
            get { return this.gender; }
        }

        public bool IsAlive { get; private set; }
        public double Weight { get; private set; }
        public int Age { get; private set; }

        public abstract int Moves { get; }
        public abstract double MinWeight { get; }

        public void GetOlder()
        {
            Age++;
        }

        public void GainWeight(double weightGained)
        {
            Weight += weightGained;
        }

        public void LoseWeight(double weightLost)
        {
            Weight -= weightLost;
        }

        public virtual void Meet(Grass grass)
        {
        }

        public virtual void Meet(Animal animal)
        {
        }

        public void Deactivate()
        {
            IsAlive = false;
        }
    }
}