namespace RainesGames.Common.States
{
    public interface IStateEventRouter
    {
        void DeregisterEventHandlers();
        void RegisterEventHandlers();
    }
}