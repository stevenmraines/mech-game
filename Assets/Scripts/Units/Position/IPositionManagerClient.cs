using TGS;

namespace RainesGames.Units.Position
{
    public interface IPositionManagerClient
    {
        Cell GetPosition();
        bool IsPlaced();
        void PlaceOnCell(int cellIndex);
        void SetCell(int cellIndex);
    }
}