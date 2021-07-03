namespace RainesGames.Common.Power
{
    /**
     * For any object that has a power limit (weapons, abilities, mech battery).
     */
    public interface IPowerContainerCapped
    {
        int GetMaxPower();
    }
}