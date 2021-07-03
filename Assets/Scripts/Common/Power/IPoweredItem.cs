namespace RainesGames.Common.Power
{
    /**
     * For items which require power (weapons, mech parts).
     */
    public interface IPoweredItem
    {
        int GetMinPower();
        bool IsPowered();
    }
}