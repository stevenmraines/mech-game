namespace RainesGames.Units
{
    public interface IUnitTransitEvents
    {
        void OnUnitEnter(AbsUnit unit);
        void OnUnitExit(AbsUnit unit);
    }
}