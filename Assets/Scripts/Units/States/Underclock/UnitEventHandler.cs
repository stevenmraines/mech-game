using RainesGames.Common.Units;
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

        public void OnUnitEnter(UnitController unit) { }

        public void OnUnitExit(UnitController unit) { }
    }
}