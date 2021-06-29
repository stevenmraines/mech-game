namespace RainesGames.Units.Abilities
{
    public interface IAbilityStatusManager
    {
        bool Active { get; }
        int StatusDuration { get; }
        int TurnsRemaining { get; }

        void Activate();
        void Countdown();
    }
}