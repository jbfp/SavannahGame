namespace SavannahGame
{
    interface IAnimalMediator
    {
        void Add<T>(T animal) where T : Animal;
        void Remove<T>(T animal) where T : Animal;
    }
}