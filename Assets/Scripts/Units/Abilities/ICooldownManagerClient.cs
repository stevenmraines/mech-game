namespace RainesGames.Units.Abilities
{
    public interface ICooldownManagerClient
    {
        void Cooldown();
        int GetCooldown();
        int GetCooldownDuration();
        bool NeedsCooldown();
        void ResetCooldown();
    }
}