namespace RainesGames.Units.Usables.Abilities
{
    public interface IAbilityStatusManager
    {
        void Activate(int duration);
        void Countdown();
        bool IsActive();
        int GetTurnsRemaining();
    }
}