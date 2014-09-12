namespace SavannahGame
{
    class StarveEvent : Event
    {
        private readonly Animal animal;
        private readonly int row;
        private readonly int column;

        public StarveEvent(Animal animal, int row, int column)
        {
            this.animal = animal;
            this.row = row;
            this.column = column;
        }

        public Animal Animal
        {
            get { return this.animal; }
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