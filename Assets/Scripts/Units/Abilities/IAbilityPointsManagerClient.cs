namespace RainesGames.Units.Abilities
{
    public interface IAbilityPointsManagerClient
    {
        void ForceSpendAllAbilityPoints();
        int GetAbilityPoints();
        bool GetFirstAbilitySpent();
        int GetStartOfTurnAbilityPoints();
        void DecrementAbilityPoints(int points = 1);
        void IncrementAbilityPoints(int points = 1);
    }
}