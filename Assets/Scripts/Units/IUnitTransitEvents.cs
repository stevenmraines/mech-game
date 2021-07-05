namespace RainesGames.Units
{
    public interface IUnitTransitEvents
    {
        void OnUnitEnter(IUnit unit);
        void OnUnitExit(IUnit unit);
    }
}