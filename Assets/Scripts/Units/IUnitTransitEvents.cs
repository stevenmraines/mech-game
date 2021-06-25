namespace RainesGames.Units
{
    public interface IUnitTransitEvents
    {
        void OnUnitEnter(UnitController unit);
        void OnUnitExit(UnitController unit);
    }
}