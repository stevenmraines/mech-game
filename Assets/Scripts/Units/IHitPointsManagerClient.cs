namespace RainesGames.Units
{
    public interface IHitPointsManagerClient
    {
        int GetHitPoints();
        int GetMaxHitPoints();
        void Repair(int hitPoints);
        void TakeDamage(int hitPoints);
    }
}
