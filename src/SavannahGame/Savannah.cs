using System;
using System.Collections.Generic;
using System.Linq;

namespace SavannahGame
{
    class Savannah
    {
        public const int Size = 20;

        private readonly Random random;
        private readonly Grass[,] savannah;
        private readonly Animal[,] animals;
        private readonly Queue<Event> events; 

        public Savannah()
        {
            this.random = new Random();
            this.savannah = new Grass[Size, Size];
            this.animals = new Animal[Size, Size];

            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    this.savannah[row, column] = new Grass(this.random.NextDouble() < 0.10, false);

                    double x = this.random.NextDouble();
                    var gender = (Gender)this.random.Next(0, 2);

                    if (x < 0.02)
                    {
                        this.animals[row, column] = new Lion(gender);
                    }
                    else if (x < 0.030)
                    {
                        this.animals[row, column] = new Rabbit(gender);
                    }
                }
            }

            this.events = new Queue<Event>();
        }

        public IReadOnlyList<Event> Events
        {
            get { return this.events.ToList().AsReadOnly(); }
        } 

        public IReadOnlyCollection<Rabbit> Rabbits
        {
            get { return this.animals.OfType<Rabbit>().ToList().AsReadOnly(); }
        }

        public IReadOnlyCollection<Lion> Lions
        {
            get { return this.animals.OfType<Lion>().ToList().AsReadOnly(); }
        }

        public IReadOnlyCollection<Grass> Grass
        {
            get { return this.savannah.OfType<Grass>().ToList().AsReadOnly(); }
        }

        public void Spawn<T>(T animal) where T : Animal
        {
            int column = this.random.Next(0, Size);
            int row = this.random.Next(0, Size);

            if (this.animals[row, column] == null)
            {
                this.animals[row, column] = animal;
            }
        }

        public Grass GetGrass(int row, int column)
        {
            return savannah[row, column];
        }

        public Animal GetAnimal(int row, int column)
        {
            return animals[row, column];
        }

        public void Move<T>(T animal, int x, int y, int dx, int dy) where T : Animal
        {
            int newX = x + dx;
            int newY = y + dy;

            if ((newX < 0 || newX >= Size) ||
                (newY < 0 || newY >= Size))
            {
                return;
            }

            if (GetAnimal(newY, newX) != null)
            {
                string message = string.Format("({0}, {1}) is occupied.", newX.ToString(), newY.ToString());
                throw new InvalidOperationException(message);
            }
            
            var moveEvent = new MoveEvent(animal, x, y, dx, dy);
            events.Enqueue(moveEvent);
            Apply(moveEvent);
        }

        public void Kill(Lion predator, Rabbit victim, int row, int column)
        {
            var killEvent = new KillEvent(predator, victim, row, column);
            events.Enqueue(killEvent);
            Apply(killEvent);
        }

        private void Apply(KillEvent e)
        {
            animals[e.Row, e.Column] = null;
        }

        private void Apply(MoveEvent e)
        {
            animals[e.Y, e.X] = null;
            animals[e.Y + e.DeltaY, e.X + e.DeltaX] = e.Animal;
        }
    }

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