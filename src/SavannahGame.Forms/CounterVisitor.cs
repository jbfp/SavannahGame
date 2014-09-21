using System.Threading;

namespace SavannahGame.Forms
{
    public class CounterVisitor : IAnimalVisitor
    {
        private int lions;
        private int rabbits;

        public int Lions
        {
            get { return this.lions; }
        }

        public int Rabbits
        {
            get { return this.rabbits; }
        }

        public void Visit(Lion lion)
        {
            Interlocked.Increment(ref this.lions);
        }

        public void Visit(Rabbit rabbit)
        {
            Interlocked.Increment(ref this.rabbits);
        }
    }
}