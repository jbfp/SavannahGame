namespace SavannahGame
{
    class GameState
    {
        private readonly SavannahState savannahState;
        private readonly Stats stats;

        public GameState(SavannahState savannahState, Stats stats)
        {
            this.savannahState = savannahState;
            this.stats = stats;
        }

        public SavannahState SavannahState
        {
            get { return this.savannahState; }
        }

        public Stats Stats
        {
            get { return this.stats; }
        }
    }
}