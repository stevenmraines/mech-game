namespace RainesGames.Units
{
    public interface IActiveUnitTransitEvents
    {
        void OnActiveUnitEnter(IUnit activeUnit, IUnit targetUnit);
        void OnActiveUnitExit(IUnit activeUnit, IUnit targetUnit);
    }
}
