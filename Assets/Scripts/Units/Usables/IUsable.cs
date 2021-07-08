namespace RainesGames.Units.Usables
{
    public interface IUsable
    {
        bool CanBeUsed();
        int GetActionCost();
        int GetFirstActionCost();
        string GetName();
        int GetSecondActionCost();
        bool IsAffordable();
        bool ShowInTray();
    }
}
