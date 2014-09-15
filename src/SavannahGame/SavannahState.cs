namespace SavannahGame
{
    class SavannahState
    {
        private readonly Grass[,] savannah;
        private readonly Animal[,] animals;

        public SavannahState(Grass[,] savannah, Animal[,] animals)
        {
            this.savannah = savannah;
            this.animals = animals;
        }

        public Grass[,] Savannah
        {
            get { return this.savannah; }
        }

        public Animal[,] Animals
        {
            get { return this.animals; }
        }
    }
}