using System;
using System.Collections.Generic;
using System.Linq;

namespace SavannahGame
{
    class Savannah
    {
        public const int Size = 20;

        private readonly Animal[,] animals;
        private readonly Queue<Event> events;
        private readonly Random random;
        private readonly Grass[,] savannah;

        public Savannah()
        {
            this.random = new Random();
            this.savannah = new Grass[Size, Size];
            this.animals = new Animal[Size, Size];

            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    this.savannah[row, column] = new Grass(this.random.NextDouble() < 0.50, false);

                    double x = this.random.NextDouble();
                    var gender = (Gender) this.random.Next(0, 2);

                    if (x < 0.05)
                    {
                        this.animals[row, column] = new Lion(gender);
                    }
                    else if (x < 0.20)
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

        public IReadOnlyCollection<Lion> Lions
        {
            get { return this.animals.OfType<Lion>().ToList().AsReadOnly(); }
        }

        public IReadOnlyCollection<Rabbit> Rabbits
        {
            get { return this.animals.OfType<Rabbit>().ToList().AsReadOnly(); }
        }

        public void Spawn(Animal animal)
        {
            int column = this.random.Next(0, Size);
            int row = this.random.Next(0, Size);

            if (this.animals[row, column] == null)
            {
                this.animals[row, column] = animal;
            }

            var spawnEvent = new SpawnEvent(animal, row, column);
            Apply(spawnEvent);
            this.events.Enqueue(spawnEvent);
        }

        public Grass GetGrass(int row, int column)
        {
            return this.savannah[row, column];
        }

        public Animal GetAnimal(int row, int column)
        {
            return this.animals[row, column];
        }

        public void Move(Animal animal, int x, int y, int dx, int dy)
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
            Apply(moveEvent);
            this.events.Enqueue(moveEvent);
        }

        public void Kill(Lion predator, Rabbit victim, int row, int column)
        {
            if (predator == null)
            {
                throw new ArgumentNullException("predator");
            }

            if (victim == null)
            {
                throw new ArgumentNullException("victim");
            }

            if ((row < 0 || row >= Size) ||
                (column < 0 || column >= Size))
            {
                throw new ArgumentOutOfRangeException();
            }

            var killEvent = new KillEvent(predator, victim, row, column);
            Apply(killEvent);
            this.events.Enqueue(killEvent);
        }

        public void Starve(Animal animal, int row, int column)
        {
            if (animal == null)
            {
                throw new ArgumentNullException("animal");
            }

            if (this.animals[row, column] == null)
            {
                string message = string.Format("No animal found at ({0}, {1}).", column.ToString(), row.ToString());
                throw new InvalidOperationException(message);
            }

            if ((row < 0 || row >= Size) ||
                (column < 0 || column >= Size))
            {
                throw new ArgumentOutOfRangeException();
            }

            var starveEvent = new StarveEvent(animal, row, column);
            Apply(starveEvent);
            this.events.Enqueue(starveEvent);
        }

        private void Apply(StarveEvent e)
        {
            this.animals[e.Row, e.Column] = null;
        }

        private void Apply(SpawnEvent e)
        {
            this.animals[e.Row, e.Column] = e.Spawn;
        }

        private void Apply(KillEvent e)
        {
            this.animals[e.Row, e.Column] = null;
        }

        private void Apply(MoveEvent e)
        {
            this.animals[e.Y, e.X] = null;
            this.animals[e.Y + e.DeltaY, e.X + e.DeltaX] = e.Animal;
        }

        public SavannahState GetCurrenState()
        {
            return new SavannahState(this.savannah, this.animals);
        }
    }
}