namespace RainesGames.Units.Selection
{
    public interface ISelectionResponse
    {
        void OnDeselect(AbsUnit selection);
        void OnSelect(AbsUnit selection);
    }
}