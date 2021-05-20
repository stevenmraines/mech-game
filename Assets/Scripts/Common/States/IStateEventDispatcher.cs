namespace RainesGames.Common.States
{
    public interface IStateEventDispatcher
    {
        void DeregisterEventHandlers();
        void RegisterEventHandlers();
    }
}