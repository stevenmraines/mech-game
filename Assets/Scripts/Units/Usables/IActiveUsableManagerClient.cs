namespace RainesGames.Units.Usables
{
    public interface IActiveUsableManagerClient
    {
        void ClearActiveUsable();
        IUsable GetActiveUsable();
        void SetActiveUsable(IUsable usable);
    }
}