using RainesGames.Common;
using RainesGames.Units.Abilities.Underclock;
using RainesGames.Units.Selection;

namespace RainesGames.Units.States.Underclock
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            UnitSelectionManager.ActiveUnit.GetAbility<UnderclockAbility>().Execute(unit);
        }

        public void OnUnitMouseEnter(UnitController unit) { }

        public void OnUnitMouseExit(UnitController unit) { }
    }
}