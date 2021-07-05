using RainesGames.Units.Selection;
using RainesGames.Units.Usables.Abilities.Overclock;

namespace RainesGames.Units.Mechs.States.Overclock
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(IUnit unit, int buttonIndex)
        {
            // TODO DRY up this code that's in every unit state event handler to get active unit and related ability
            UnitSelectionManager.ActiveUnit.GetAbility<OverclockAbility>().Execute(unit);
        }

        public void OnUnitEnter(IUnit unit) { }

        public void OnUnitExit(IUnit unit) { }
    }
}