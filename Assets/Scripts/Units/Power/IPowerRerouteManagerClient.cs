using RainesGames.Common.Power;

namespace RainesGames.Units.Power
{
    public interface IPowerRerouteManagerClient
    {
        void DiscardPowerState();
        int GetMaxPower();
        int GetPower();
        void RecordPowerState();
        void RevertPowerState();
        void TransferPowerFrom(IPowerContainerInteractable container, int power = 1);
        void TransferPowerTo(IPowerContainerInteractable container, int power = 1);
    }
}