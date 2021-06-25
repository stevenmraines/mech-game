namespace RainesGames.Units.Abilities
{
    public interface IAbilityCost
    {
        int FirstAbilityCost { get; }
        int SecondAbilityCost { get; }

        int GetAbilityPointCost();
    }
}