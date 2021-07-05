using RainesGames.Common.Power;

namespace RainesGames.Units.Mechs.Classes
{
    public interface IMechClass : IPowerContainerCapped
    {
        int GetBaseMovement();
        string GetClassName();
        int GetStartOfTurnActionPoints();
    }
}