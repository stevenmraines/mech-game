namespace RainesGames.Units
{
    public interface IActiveUnitClickEvents
    {
        void OnActiveUnitClick(IUnit activeUnit, IUnit targetUnit, int buttonIndex);
    }
}
