using TGS;

namespace RainesGames.Units.Usables
{
    public interface IRangedUsable
    {
        int GetMaxRange();
        int GetMinRange();
        bool HasLOS(IUnit targetUnit);
        bool InRange(Cell targetCell);
        bool NeedsLOS();
    }
}
