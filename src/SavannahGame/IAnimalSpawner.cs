namespace SavannahGame
{
    public interface IAnimalSpawner
    {
        void Spawn<T>(T animal) where T : Animal;
    }
}