namespace RainesGames.Units.Abilities.FactoryReset
{
    public interface IFactoryResetClient
    {
        void FactoryReset();
        int GetFactoryResetTurnsRemaining();
        bool IsFactoryReset();
    }
}