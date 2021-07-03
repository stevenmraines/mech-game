namespace RainesGames.Common.Power
{
    /**
     * Main interface for anything that can contain power (weapons, mech parts, mech battery).
     */
    public interface IPowerContainer
    {
        int GetMaxPower();
        int GetPower();
    }
}