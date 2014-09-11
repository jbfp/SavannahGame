namespace SavannahGame
{
    class Grass
    {
        private int ticks;

        public Grass(bool isAlive)
        {
            IsAlive = isAlive;
        }

        public bool IsAlive { get; private set; }

        public void Tick()
        {
            if (IsAlive)
            {
                return;
            }

            if (++this.ticks == 20)
            {
                IsAlive = true;
            }
        }

        public void Kill()
        {
            IsAlive = false;
            this.ticks = 0;
        }
    }
}