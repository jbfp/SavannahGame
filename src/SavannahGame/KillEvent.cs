namespace SavannahGame
{
    class KillEvent : Event
    {
        private readonly Lion predator;
        private readonly Rabbit prey;
        private readonly int row;
        private readonly int column;

        public KillEvent(Lion predator, Rabbit prey, int row, int column)
        {
            this.predator = predator;
            this.prey = prey;
            this.row = row;
            this.column = column;
        }

        public Lion Predator
        {
            get { return this.predator; }
        }

        public Rabbit Prey
        {
            get { return this.prey; }
        }

        public int Row
        {
            get { return this.row; }
        }

        public int Column
        {
            get { return this.column; }
        }
    }
}