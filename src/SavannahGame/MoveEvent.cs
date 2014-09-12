namespace SavannahGame
{
    class MoveEvent : Event
    {
        private readonly Animal animal;
        private readonly int x;
        private readonly int y;
        private readonly int dx;
        private readonly int dy;

        public MoveEvent(Animal animal, int x, int y, int dx, int dy)
        {
            this.animal = animal;
            this.x = x;
            this.y = y;
            this.dx = dx;
            this.dy = dy;
        }

        public Animal Animal
        {
            get { return this.animal; }
        }

        public int X
        {
            get { return this.x; }
        }

        public int Y
        {
            get { return this.y; }
        }

        public int DeltaX
        {
            get { return this.dx; }
        }

        public int DeltaY
        {
            get { return this.dy; }
        }
    }
}