namespace RainesGames.Units.Abilities.Underclock
{
    public interface IUnderclockClient
    {
        int GetUnderclockedTurnsRemaining();
        bool IsUnderclocked();
        void Underclock(int duration);
    }
}