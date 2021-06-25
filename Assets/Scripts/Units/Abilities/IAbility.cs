using RainesGames.Units.States;

namespace RainesGames.Units.Abilities
{
    public interface IAbility : IAbilityCost
    {
        IUnitState State { get; }

        bool AbilityIsAffordable();
    }
}