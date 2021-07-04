using RainesGames.Units.States;

namespace RainesGames.Units.Usables
{
    public interface IUsable
    {
        bool CanBeUsed();
        int GetActionCost();
        int GetFirstActionCost();
        string GetName();
        int GetSecondActionCost();
        UnitState GetState();
        bool IsAffordable();
        bool ShowInTray();
    }
}
