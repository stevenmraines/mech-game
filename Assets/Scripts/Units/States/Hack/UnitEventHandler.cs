using RainesGames.Common;
using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.Selection;

namespace RainesGames.Units.States.Hack
{
    public class UnitEventHandler : IUnitEvents
    {
        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            UnitSelectionManager.ActiveUnit.GetAbility<HackAbility>().Execute(unit);
        }

        public void OnUnitMouseEnter(UnitController unit) { }

        public void OnUnitMouseExit(UnitController unit) { }
    }
}