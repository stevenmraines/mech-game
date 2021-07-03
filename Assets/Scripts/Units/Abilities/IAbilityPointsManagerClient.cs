namespace RainesGames.Units.Abilities
{
    public interface IAbilityPointsManagerClient
    {
        bool FirstAbilitySpent();
        void ForceSpendAllAbilityPoints();
        int GetAbilityPoints();
        int GetStartOfTurnAbilityPoints();
        void DecrementAbilityPoints(int points = 1);
        void IncrementAbilityPoints(int points = 1);
    }
}