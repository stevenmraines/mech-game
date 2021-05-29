namespace RainesGames.Units.Selection
{
    public interface ISelectionResponse
    {
        void OnDeselect(UnitController selection);
        void OnSelect(UnitController selection);
    }
}