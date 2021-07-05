namespace RainesGames.Units.Usables
{
    public interface IActionPointsManagerClient
    {
        bool FirstActionSpent();
        void ForceSpendAllActionPoints();
        int GetActionPoints();
        int GetStartOfTurnActionPoints();
        void DecrementActionPoints(int points = 1);
        void IncrementActionPoints(int points = 1);
    }
}