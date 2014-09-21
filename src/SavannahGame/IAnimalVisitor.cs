namespace SavannahGame
{
    public interface IAnimalVisitor
    {
        void Visit(Lion lion);
        void Visit(Rabbit rabbit);
    }
}