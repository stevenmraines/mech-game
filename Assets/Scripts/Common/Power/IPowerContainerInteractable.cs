namespace RainesGames.Common.Power
{
    /**
     * Interface for power containers that can have power added to/removed from them (weapons, mech parts).
     */
    public interface IPowerContainerInteractable : IPowerContainer
    {
        void AddPower(int power);
        void RemovePower(int power);
    }
}