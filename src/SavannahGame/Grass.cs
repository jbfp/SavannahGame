namespace SavannahGame
{
    public class Grass
    {
        private readonly int ttl;

        private int ticks;

        public Grass(bool isAlive, int ttl)
        {
            this.ttl = ttl;
            IsAlive = isAlive;
        }

        public bool IsAlive { get; private set; }

        public void Tick()
        {
            if (++this.ticks % ttl == 0)
            {
                IsAlive = !IsAlive;
            }
        }

        public void Deactivate()
        {
            IsAlive = false;
            this.ticks = 0;
        }
    }
}