namespace RainesGames.Common.Power
{
    public interface IPoweredItem
    {
        int MinPower { get; }

        bool IsPowered();
    }
}