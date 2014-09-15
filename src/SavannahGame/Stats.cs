namespace SavannahGame
{
    class Stats
    {
        private readonly int animalsStarved;
        private readonly int rabbitsEaten;
        private readonly int grassEaten;

        public Stats(int animalsStarved, int rabbitsEaten, int grassEaten)
        {
            this.animalsStarved = animalsStarved;
            this.rabbitsEaten = rabbitsEaten;
            this.grassEaten = grassEaten;
        }

        public int AnimalsStarved
        {
            get { return this.animalsStarved; }
        }

        public int RabbitsEaten
        {
            get { return this.rabbitsEaten; }
        }

        public int GrassEaten
        {
            get { return this.grassEaten; }
        }
    }
}