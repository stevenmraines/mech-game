using RainesGames.Common;
using RainesGames.Units.Abilities.Overclock;
using RainesGames.Units.Selection;

namespace RainesGames.Units.States.Overclock
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            // TODO DRY up this code that's in every unit state event handler to get active unit and related ability
            UnitSelectionManager.ActiveUnit.GetAbility<OverclockAbility>().Execute(unit);
        }

        public void OnUnitMouseEnter(UnitController unit) { }

        public void OnUnitMouseExit(UnitController unit) { }
    }
}