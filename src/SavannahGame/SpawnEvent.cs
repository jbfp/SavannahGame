namespace SavannahGame
{
    class SpawnEvent : Event
    {
        private readonly Animal spawn;
        private readonly int row;
        private readonly int column;

        public SpawnEvent(Animal spawn, int row, int column)
        {
            this.spawn = spawn;
            this.row = row;
            this.column = column;
        }

        public Animal Spawn
        {
            get { return this.spawn; }
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