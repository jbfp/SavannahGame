namespace SavannahGame
{
    class Grass
    {
        private readonly bool willRevive;

        private int ticks;

        public Grass(bool isAlive, bool willRevive)
        {
            IsAlive = isAlive;
            this.willRevive = willRevive;
        }

        public bool IsAlive { get; private set; }

        public void Tick()
        {
            if (IsAlive)
            {
                return;
            }

            if (!willRevive)
            {
                return;
            }

            if (++this.ticks == 20)
            {
                //IsAlive = true;
            }
        }

        public void Kill()
        {
            IsAlive = false;
            this.ticks = 0;
        }
    }
}