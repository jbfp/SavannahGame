namespace SavannahGame
{
    public interface IFoodChain
    {
        void Spawn<T>(T animal) where T : Animal;
        void Destroy<T>(T animal) where T : Animal;
    }
}