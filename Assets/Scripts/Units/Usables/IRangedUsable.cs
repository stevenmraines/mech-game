using TGS;

namespace RainesGames.Units.Usables
{
    public interface IRangedUsable
    {
        int GetMaxRange();
        int GetMinRange();
        bool InRange(Cell targetCell);
    }
}
