namespace RainesGames.Units.Usables.Abilities.FactoryReset
{
    public interface IFactoryResetClient
    {
        void FactoryReset(int duration);
        int GetFactoryResetTurnsRemaining();
        bool IsFactoryReset();
    }
}