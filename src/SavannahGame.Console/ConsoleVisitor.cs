using System;

namespace SavannahGame.Console
{
    class ConsoleVisitor : IAnimalVisitor, ISavannahVisitor
    {
        public void Visit(Lion lion)
        {
            Visit(lion, 'L', ConsoleColor.DarkCyan, ConsoleColor.Cyan);
        }

        public void Visit(Rabbit rabbit)
        {
            Visit(rabbit, 'R', ConsoleColor.Gray, ConsoleColor.White);
        }

        public void Visit(Grass grass)
        {
            System.Console.SetCursorPosition(grass.X, grass.Y);
            System.Console.ForegroundColor = grass.IsAlive ? ConsoleColor.Green : ConsoleColor.Yellow;
            System.Console.Write(grass.IsAlive ? "#" : "·");
        }

        private static void Visit<T>(T animal, char letter, ConsoleColor male, ConsoleColor female) where T : Animal
        {
            System.Console.SetCursorPosition(animal.X, animal.Y);

            switch (animal.Gender)
            {
                case Gender.Male:
                    System.Console.ForegroundColor = male;
                    break;
                case Gender.Female:
                    System.Console.ForegroundColor = female;
                    break;
            }

            System.Console.Write(letter.ToString());
        }
    }
}