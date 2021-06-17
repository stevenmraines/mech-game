namespace RainesGames.Common.Power
{
    public interface IPowerContainerInteractable : IPowerContainer
    {
        void AddPower(int power);
        void RemovePower(int power);
    }
}