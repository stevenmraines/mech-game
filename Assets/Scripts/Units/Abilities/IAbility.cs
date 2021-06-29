using RainesGames.Units.States;

namespace RainesGames.Units.Abilities
{
    public interface IAbility
    {
        int FirstAbilityCost { get; }
        int SecondAbilityCost { get; }
        bool ShowInTray { get; }
        UnitState State { get; }

        int GetAbilityCost();
        bool IsAffordable();
    }
}