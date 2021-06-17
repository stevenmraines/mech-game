using RainesGames.Common.Actions;
using RainesGames.Units.States;

namespace RainesGames.Units.Abilities
{
    public interface IAbility : IActionCost
    {
        AbsUnitState State { get; }

        bool ActionIsAffordable();
    }
}