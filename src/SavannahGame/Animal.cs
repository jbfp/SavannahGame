namespace SavannahGame
{
    public abstract class Animal : ISavannahVisitor, IAnimalVisitor
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

        public int X { get; set; }
        public int Y { get; set; }

        protected abstract double MinWeight { get; }

        public bool IsAlive { get; private set; }
        public double Weight { get; private set; }
        public int Age { get; private set; }

        public abstract int Moves { get; }

        public void GetOlder()
        {
            if (IsAlive == false)
            {
                return;
            }

            Age++;
        }

        public void GainWeight(double weightGained)
        {
            if (IsAlive == false)
            {
                return;
            }

            Weight += weightGained;
        }

        public void LoseWeight(double weightLost)
        {
            if (IsAlive == false)
            {
                return;
            }

            Weight -= weightLost;

            if (Weight < MinWeight)
            {
                Deactivate();
            }
        }

        public void Deactivate()
        {
            IsAlive = false;
        }

        public virtual void Visit(Grass grass)
        {
        }

        public virtual void Visit(Lion lion)
        {
        }

        public virtual void Visit(Rabbit rabbit)
        {
        }

        public abstract void Accept(IAnimalVisitor visitor);
    }
}