namespace SavannahGame
{
    public class Grass
    {
        private readonly int ttl;

        private int ticks;

        public Grass(int ttl, bool isAlive, int x, int y)
        {
            this.ttl = ttl;
            IsAlive = isAlive;
            X = x;
            Y = y;
        }

        public bool IsAlive { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Grow()
        {
            if (++this.ticks % ttl == 0)
            {
                IsAlive = true;
            }
        }

        public void Deactivate()
        {
            IsAlive = false;
            this.ticks = 0;
        }        

        public void Accept(ISavannahVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}