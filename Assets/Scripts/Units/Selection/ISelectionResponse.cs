namespace RainesGames.Units.Selection
{
    public interface ISelectionResponse
    {
        void OnDeselect(IUnit selection);
        void OnSelect(IUnit selection);
    }
}