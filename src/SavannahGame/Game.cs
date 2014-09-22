using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavannahGame
{
    public class Game
    {
        private static readonly Random Random = new Random();

        private readonly Savannah savannah;

        public Game(Savannah savannah)
        {
            this.savannah = savannah;
        }

        public void Accept(ISavannahVisitor visitor)
        {
            foreach (var grass in this.savannah.Grasses)
            {
                grass.Accept(visitor);
            }
        }

        public void Accept(IAnimalVisitor visitor)
        {
            foreach (var animal in this.savannah.Animals)
            {
                animal.Accept(visitor);
            }
        }

        public IEnumerable<Action> Tick()
        {
            var animals = this.savannah.Animals;

            foreach (var animal in animals)
            {
                foreach (var action in Move(animal))
                {
                    yield return action;
                }
            }

            foreach (var animal in animals)
            {
                foreach (var action in Act(animal))
                {
                    yield return action;
                }
            }

            animals = this.savannah.Animals;

            foreach (var animal in animals)
            {
                foreach (var action in Cleanup(animal))
                {
                    yield return action;
                }
            }

            yield return () => Parallel.ForEach(this.savannah.Grasses, grass => grass.Grow());
        }

        private IEnumerable<Action> Move(Animal animal)
        {
            for (int move = 0; move < animal.Moves; move++)
            {
                int dx = Random.Next(-1, 2);
                int dy = Random.Next(-1, 2);

                if (dx == 0 && dy == 0)
                {
                    continue;
                }

                yield return () => this.savannah.Move(animal, animal.Y + dy, animal.X + dx);
            }
        }

        private IEnumerable<Action> Act(Animal animal)
        {
            if (animal.IsAlive == false)
            {
                yield break;
            }

            animal.GetOlder();
            animal.LoseWeight(animal.Weight * 0.10);

            // Dies from overpopulation or starvation?
            int max = this.savannah.NumTiles;
            int animals = this.savannah.Animals.Count(a => a.GetType() == animal.GetType());
            double k = Random.NextDouble();
            bool dies = k < ((1.0 * animals) / (1.0 * max)) || animal.Age > Random.Next(5, 20);

            if (dies)
            {
                yield return animal.Deactivate;
                yield break;
            }

            for (int dy = -1; dy <= 1; dy++)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    int x = animal.X + dx;
                    int y = animal.Y + dy;

                    Grass neighbourGrass = this.savannah.Grasses.SingleOrDefault(g => g.X == x && g.Y == y);
                    Animal neighbourAnimal = this.savannah.Animals.SingleOrDefault(a => a.IsAlive && a.X == x && a.Y == y);

                    if (neighbourGrass!= null)
                    {
                        yield return () => neighbourGrass.Accept(animal);
                    }

                    if (neighbourAnimal != null)
                    {
                        yield return () => animal.Accept(neighbourAnimal);
                    }
                }
            }
        }

        private IEnumerable<Action> Cleanup(Animal animal)
        {
            if (animal.IsAlive == false)
            {
                yield return () => this.savannah.Remove(animal);
            }
        }
    }
}